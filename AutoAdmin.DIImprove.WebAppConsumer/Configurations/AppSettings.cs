
using AutoAdmin.DIImprove.Injection.Attributes;

namespace AutoAdmin.DIImprove.WebAppConsumer.Configurations
{
    [ConfigurationSection("AppSettings")]
    public class AppSettings
    {
        public string Name { get; set; }

        public bool IsLegacy { get; set; }

        public int Handles { get; set; }

        public override string ToString()
        {
            return $@"Name: {Name}
IsLegacy: {IsLegacy}
Handles: {Handles}";
        }
    }
}