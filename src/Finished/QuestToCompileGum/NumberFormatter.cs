using System.Globalization;

namespace QuestToCompileGum;

public static class NumberFormatter
{
    public static string Format(long n)
    {
        if (n < 10_000) return n.ToString("N0", CultureInfo.InvariantCulture);
        if (n < 1_000_000) return Scaled(n, 1_000, "K");
        if (n < 1_000_000_000) return Scaled(n, 1_000_000, "M");
        if (n < 1_000_000_000_000) return Scaled(n, 1_000_000_000, "B");
        return Scaled(n, 1_000_000_000_000, "T");
    }

    static string Scaled(long n, long divisor, string suffix)
    {
        double v = (double)n / divisor;
        string s = v.ToString("0.0", CultureInfo.InvariantCulture);
        if (s.EndsWith(".0")) s = s.Substring(0, s.Length - 2);
        return s + suffix;
    }
}
