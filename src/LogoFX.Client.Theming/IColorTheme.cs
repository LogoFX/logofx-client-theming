namespace LogoFX.Client.Theming
{
    public interface IColorTheme
    {
        string Name { get; }

        IColorEntry[] Entries { get; }
    }
}