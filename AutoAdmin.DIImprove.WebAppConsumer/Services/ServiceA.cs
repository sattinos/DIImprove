using AutoAdmin.DIImprove.Injection.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace AutoAdmin.DIImprove.WebAppConsumer.Services
{
    [InjectAs(ServiceLifetime.Singleton)]
    public class ServiceA
    {
        public string DoSomething()
        {
            return "Service A Singleton Service";
        }
    }
}