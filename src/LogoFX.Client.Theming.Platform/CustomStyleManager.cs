using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using JetBrains.Annotations;

namespace LogoFX.Client.Theming
{
    [UsedImplicitly]
    public sealed class CustomStyleManager : ICustomStyleManager
    {
        #region Fields

        private readonly Dictionary<Type, List<CustomStyleBase>> _customStyles =
            new Dictionary<Type, List<CustomStyleBase>>();

        #endregion

        #region Private Members

        private void AddCustomStyle(Type targetType, CustomStyleBase customStyle)
        {
            if (!_customStyles.TryGetValue(targetType, out var list))
            {
                list = new List<CustomStyleBase>();
                _customStyles.Add(targetType, list);
            }

            list.Add(customStyle);
        }

        private void AddDirectAssembly(Assembly assembly)
        {
            var types = assembly.ExportedTypes.Where(x => x.IsSubclassOf(typeof(ResourceDictionary)));

            foreach (var resourceDictionaryType in types)
            {
                var at = resourceDictionaryType.GetCustomAttribute<CustomControlStyleAttribute>();
                if (at == null)
                {
                    continue;
                }

                AddCustomStyle(at.TargetType, new CompiledCustomStyle(at.Name, resourceDictionaryType));
            }
        }

        private void AddXaml(Type targetType, string name, string xamlText)
        {
            AddCustomStyle(targetType, new RawCustomStyle(name, xamlText));
        }

        #endregion

        #region ICustomStyleManager

        string[] ICustomStyleManager.GetStyleNames(Type type)
        {
            return _customStyles.TryGetValue(type, out var customStyles)
                ? customStyles.Select(x => x.Name).ToArray()
                : null;
        }

        CustomColor[] ICustomStyleManager.GetColors(Type targetType, string customStyleName)
        {
            var colors = _customStyles.TryGetValue(targetType, out var customStyles)
                ? customStyles.SingleOrDefault(x => x.Name == customStyleName)?.GetColors()
                : null;

            return colors?.ToArray();
        }

        ResourceDictionary ICustomStyleManager.GetCustomResourceDictionary(Type type, string name, IColorEntry[] colorEntries)
        {
            if (!_customStyles.TryGetValue(type, out var customStyles))
            {
                return null;
            }

            var customStyle = customStyles.SingleOrDefault(x => x.Name == name);
            return customStyle?.GetCustomResourceDictionary(colorEntries);
        }

        void ICustomStyleManager.AddDirectAssembly(Assembly assembly)
        {
            AddDirectAssembly(assembly);
        }
        
        void ICustomStyleManager.AddXaml(Type targetType, string name, string xamlText)
        {
            AddXaml(targetType, name, xamlText);
        }

        #endregion
    }
}