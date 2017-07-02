using System;

namespace LogoFX.Client.Theming
{
    [Serializable]
    public sealed class ColorTheme : IColorTheme
    {
        public string Name { get; set; }

        public IColorEntry[] Entries { get; set; }
    }
}