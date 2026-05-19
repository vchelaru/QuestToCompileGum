using Gum.Forms;
using Gum.Forms.Controls;
using Gum.Mvvm;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameAndGum.Renderables;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using QuestToCompileGum.Screens;
using System;

namespace QuestToCompileGum;

public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    GumService GumUI => GumService.Default;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        if (GraphicsAdapter.DefaultAdapter.IsProfileSupported(GraphicsProfile.HiDef))
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
        IsMouseVisible = true;
        Window.AllowUserResizing = true;

        Window.ClientSizeChanged += HandleWindowSizeChanged;
    }

    private void HandleWindowSizeChanged(object sender, EventArgs e)
    {
        GumUI.CanvasWidth = Window.ClientBounds.Width;
        GumUI.CanvasHeight = Window.ClientBounds.Height;
    }

    MainScreen mainScreen;

    protected override void Initialize()
    {
        base.Initialize();
        GumUI.Initialize(this, "GumProject/GumProject.gumx");
        ShapeRenderer.Self.Initialize();
        mainScreen = new MainScreen();
        mainScreen.AddToRoot();
    }

    protected override void Update(GameTime gameTime)
    {
        GumUI.Update(gameTime);
        mainScreen?.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        GumUI.Draw();
        base.Draw(gameTime);
    }
}

