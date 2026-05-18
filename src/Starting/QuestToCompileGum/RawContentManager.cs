using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace QuestToCompileGum;

/// <summary>
/// A ContentManager that supports loading raw asset files (images and audio)
/// without the content pipeline. MonoGame's built-in ContentManager only
/// supports pipeline-processed .xnb files; this shim bridges the gap so
/// code written for XnaFiddle or KNI works unchanged.
/// Uses TitleContainer.OpenStream for cross-platform compatibility (desktop,
/// Android, and web all resolve content paths differently).
/// </summary>
public class RawContentManager : ContentManager
{
    static readonly string[] ImageExtensions = { ".png", ".jpg", ".jpeg", ".bmp" };
    static readonly string[] AudioExtensions = { ".wav" };
    static readonly bool IsDesktop = !OperatingSystem.IsAndroid() && !OperatingSystem.IsBrowser();
    // KNI's Texture2D.FromStream returns straight (non-premultiplied) alpha, but XNA-style
    // code (SpriteBatch + BlendState.AlphaBlend) expects premultiplied. MonoGame's FromStream
    // already premultiplies, so we only do it on KNI. Detected at runtime by assembly name
    // to avoid pushing a #if KNI / csproj DefineConstants flag down to every exported project.
    // Fragile: fails open (skips premultiply) if KNI ever renames its graphics assembly away
    // from Xna.Framework.*.
    static readonly bool NeedsPremultiply = typeof(Texture2D).Assembly.GetName().Name?.StartsWith("Xna.Framework") == true;

    readonly IGraphicsDeviceService _graphics;

    static void PremultiplyAlpha(Texture2D texture)
    {
        Color[] pixels = new Color[texture.Width * texture.Height];
        texture.GetData(pixels);
        for (int i = 0; i < pixels.Length; i++)
        {
            byte a = pixels[i].A;
            pixels[i] = new Color((byte)(pixels[i].R * a / 255), (byte)(pixels[i].G * a / 255), (byte)(pixels[i].B * a / 255), a);
        }
        texture.SetData(pixels);
    }

    public RawContentManager(IServiceProvider services, string rootDirectory)
        : base(services, rootDirectory)
    {
        _graphics = (IGraphicsDeviceService)services.GetService(typeof(IGraphicsDeviceService));
    }

    public override T Load<T>(string assetName)
    {
        if (typeof(T) == typeof(Texture2D))
        {
            foreach (var ext in ImageExtensions)
            {
                string path = Path.Combine(RootDirectory, assetName + ext);
                byte[] bytes = TryReadAllBytes(path);
                if (bytes == null) continue;
                // If the user dropped an .xnb in disguise (or any XNB-headered blob), skip
                // raw decode and fall through to the pipeline-based base.Load<T>.
                if (IsXnb(bytes)) break;
                using var stream = new MemoryStream(bytes);
                var tex = Texture2D.FromStream(_graphics.GraphicsDevice, stream);
                if (NeedsPremultiply) PremultiplyAlpha(tex);
                return (T)(object)tex;
            }
        }

        if (typeof(T) == typeof(SoundEffect))
        {
            foreach (var ext in AudioExtensions)
            {
                string path = Path.Combine(RootDirectory, assetName + ext);
                byte[] bytes = TryReadAllBytes(path);
                if (bytes == null) continue;
                if (IsXnb(bytes)) break;
                using var stream = new MemoryStream(bytes);
                return (T)(object)SoundEffect.FromStream(stream);
            }
        }

        return base.Load<T>(assetName);
    }

    static bool IsXnb(byte[] bytes) =>
        bytes != null && bytes.Length >= 3 && bytes[0] == (byte)'X' && bytes[1] == (byte)'N' && bytes[2] == (byte)'B';

    static byte[] TryReadAllBytes(string path)
    {
        if (IsDesktop)
        {
            if (!File.Exists(path)) return null;
            return File.ReadAllBytes(path);
        }
        try
        {
            using var stream = TitleContainer.OpenStream(path);
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }
        catch (FileNotFoundException) { return null; }
    }
}
