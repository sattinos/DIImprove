using Microsoft.Extensions.DependencyInjection;
using AutoAdmin.DIImprove.Injection.Attributes;

namespace AutoAdmin.DIImprove.WebAppConsumer.Services
{
    [InjectAs(ServiceLifetime.Scoped)]
    public class ServiceB
    {
        public string DoSomething()
        {
            return "Service B Singleton Service";
        }
    }
}