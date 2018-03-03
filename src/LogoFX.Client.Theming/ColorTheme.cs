using System;
using JetBrains.Annotations;

namespace LogoFX.Client.Theming
{
    [Serializable]
    public sealed class ColorTheme : IColorTheme
    {
        public string Name { get; [UsedImplicitly] set; }

        public IColorEntry[] Entries { get; [UsedImplicitly] set; }
    }
}