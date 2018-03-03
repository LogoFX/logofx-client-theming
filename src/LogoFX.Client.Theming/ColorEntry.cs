using System;
using JetBrains.Annotations;

namespace LogoFX.Client.Theming
{
    [Serializable]
    public sealed class ColorEntry : IColorEntry
    {
        public object ResourceKey { get; [UsedImplicitly] set; }

        private string _caption;
        public string Caption
        {
            get => _caption ?? ResourceKey.ToString();
            set => _caption = value;
        }

        public uint Color { get; set; }
    }
}