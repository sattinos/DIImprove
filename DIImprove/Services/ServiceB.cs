using Microsoft.Extensions.DependencyInjection;
using DIImprove.Injection.Attributes;

namespace DIImprove.Services
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