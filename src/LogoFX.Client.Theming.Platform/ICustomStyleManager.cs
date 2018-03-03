using System;
using System.Reflection;
using System.Windows;

namespace LogoFX.Client.Theming
{   
    public interface ICustomStyleManager
    {
        string[] GetStyleNames(Type type);       

        CustomColor[] GetColors(Type targetType, string customStyleName);
        
        ResourceDictionary GetCustomResourceDictionary(Type type, string name, IColorEntry[] colorEntries);

        void AddDirectAssembly(Assembly assembly);

        void AddXaml(Type targetType, string name, string xamlText);
    }
}