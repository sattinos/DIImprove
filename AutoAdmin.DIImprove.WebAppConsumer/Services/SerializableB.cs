using AutoAdmin.DIImprove.Injection.Attributes;
using AutoAdmin.DIImprove.WebAppConsumer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AutoAdmin.DIImprove.WebAppConsumer.Services
{
    [InjectAs(ServiceLifetime.Transient, typeof(ISerializable))]
    public class SerializableB : ISerializable
    {
        public string Serialize()
        {
            return "SerializableB serialized data";
        }
    }
}