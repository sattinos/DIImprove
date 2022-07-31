using System;
using Microsoft.Extensions.DependencyInjection;

namespace AutoAdmin.DIImprove.Injection.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectAsAttribute : Attribute
    {
        public ServiceLifetime ServiceLifetime { get; }
        public Type ImplementedInterface { get; }
        
        public InjectAsAttribute(ServiceLifetime serviceLifetime, Type implementedInterface = null)
        {
            ServiceLifetime = serviceLifetime;
            ImplementedInterface = implementedInterface;
        }
    }
}