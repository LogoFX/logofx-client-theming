using System;

namespace LogoFX.Client.Theming
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CustomControlStyleAttribute : Attribute
    {
        public CustomControlStyleAttribute(string name, Type targetType)
        {
            Name = name;
            TargetType = targetType;
        }

        public Type TargetType { get; set; }

        public string Name { get; set; }
    }
}