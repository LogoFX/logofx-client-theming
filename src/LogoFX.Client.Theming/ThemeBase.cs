using System;
using System.Windows;

namespace LogoFX.Client.Theming
{
    internal abstract class ThemeBase : ITheme, IThemeNotifyChanged
    {
        private ResourceDictionary[] _cache;
        private IColorTheme[] _colorThemes;

        protected ThemeBase(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected abstract ResourceDictionary[] LoadResoucesInternal();

        protected IColorTheme[] GetColorThemes()
        {
            return _colorThemes;
        }

        public T Get<T>(string key)
        {
            if (_cache == null)
            {
                _cache = LoadResoucesInternal();
            }

            foreach (var r in _cache)
            {
                if (r.Contains(key))
                {
                    return (T) r[key];
                }
            }

            return default(T);
        }

        public void ApplyColorThemes(params IColorTheme[] colorThemes)
        {
            _colorThemes = colorThemes;
            ColorThemeChanged(this, EventArgs.Empty);
        }

        public void LoadResoucesAsync(Action<ResourceDictionary[]> callback)
        {

            var action = new Func<ResourceDictionary[]>(LoadResoucesInternal);
            action.BeginInvoke(ar =>
            {
                Func<ResourceDictionary[]> action1 = (Func<ResourceDictionary[]>) ar.AsyncState;
                var cache = action1.EndInvoke(ar);
                callback(cache);
            }, action);
        }

        public ResourceDictionary[] LoadResources()
        {
            _cache = LoadResoucesInternal();
            return _cache;
        }

        public event EventHandler ColorThemeChanged = delegate { };
    }
}