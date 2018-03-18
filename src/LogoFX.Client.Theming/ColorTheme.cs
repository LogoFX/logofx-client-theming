using System;
using JetBrains.Annotations;

namespace LogoFX.Client.Theming
{
    [Serializable]
    public sealed class ColorTheme
    {
        public string Name { get; [UsedImplicitly] set; }

        public ResourceEntry[] Entries { get; [UsedImplicitly] set; }
    }
}