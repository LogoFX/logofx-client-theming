using System;

namespace LogoFX.Client.Theming
{
    public interface IThemeNotifyChanged
    {
        event EventHandler ColorThemeChanged;
    }
}