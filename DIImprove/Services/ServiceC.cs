using Microsoft.Extensions.DependencyInjection;
using DIImprove.Injection.Attributes;

namespace DIImprove.Services
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