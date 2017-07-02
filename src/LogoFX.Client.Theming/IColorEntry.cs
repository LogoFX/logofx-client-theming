namespace LogoFX.Client.Theming
{
    public interface IColorEntry
    {
        object ResourceKey { get; }
        string Caption { get; }
        uint Color { get; set; }
    }
}