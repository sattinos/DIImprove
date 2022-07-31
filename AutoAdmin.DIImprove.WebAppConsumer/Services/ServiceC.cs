using Microsoft.Extensions.DependencyInjection;
using AutoAdmin.DIImprove.Injection.Attributes;

namespace AutoAdmin.DIImprove.WebAppConsumer.Services
{
    [InjectAs(ServiceLifetime.Transient)]
    public class ServiceC
    {
        public string DoSomething()
        {
            return "Service C Singleton Service";
        }
    }
}