using Microsoft.Extensions.DependencyInjection;
using DIImprove.Injection.Attributes;
using DIImprove.Services.Interfaces;

namespace DIImprove.Services
{
    [InjectAs(ServiceLifetime.Transient, typeof(ISerializable))]
    public class SerializableA : ISerializable
    {
        public string Serialize()
        {
            return "SerializableA serialized data";
        }
    }
}