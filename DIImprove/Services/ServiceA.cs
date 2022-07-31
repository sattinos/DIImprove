using Microsoft.Extensions.DependencyInjection;
using DIImprove.Injection.Attributes;

namespace DIImprove.Services
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