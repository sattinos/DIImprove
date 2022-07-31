using Microsoft.Extensions.DependencyInjection;
using AutoAdmin.DIImprove.Injection.Attributes;
using AutoAdmin.DIImprove.WebAppConsumer.Services.Interfaces;

namespace AutoAdmin.DIImprove.WebAppConsumer.Services
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