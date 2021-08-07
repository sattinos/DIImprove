using System;

namespace DIImprove.Injection.Attributes
{
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ConfigurationSectionAttribute : Attribute
    {
        public string KeyName { get; }
        public ConfigurationSectionAttribute(string keyName)
        {
            KeyName = keyName;
        }
    }
}