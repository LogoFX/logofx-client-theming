using System;
using System.Windows;

namespace LogoFX.Client.Theming
{
    public interface ITheme
    {
        string Name { get; }
        void LoadResoucesAsync(Action<ResourceDictionary[]> callback);
        ResourceDictionary[] LoadResources();
        T Get<T>(string key);
        void ApplyColorThemes(params IColorTheme[] colorThemes);
    }
}