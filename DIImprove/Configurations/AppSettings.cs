using DIImprove.Injection.Attributes;

namespace DIImprove.Configurations
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