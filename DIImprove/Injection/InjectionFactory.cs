using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DIImprove.Core.Reflection;
using DIImprove.Injection.Attributes;

namespace DIImprove.Injection
{
    public static class InjectionFactory
    {
        public static void StartInjection(IServiceCollection services, IConfiguration configuration, Assembly assembly = null)
        {
            InjectServices(services, assembly);
            InjectConfigurationSections(services, configuration, assembly);
        }

        private static void InjectConfigurationSections(IServiceCollection services, IConfiguration configuration, Assembly assembly = null)
        {
            var types = ReflectionExtension.GetTypesWithAttribute<ConfigurationSectionAttribute>(assembly);
            foreach (var type in types)
            {
                var sectionAttribute = type.GetCustomAttribute<ConfigurationSectionAttribute>();
                if (sectionAttribute != null)
                {
                    var configurationSection = configuration.GetSection(sectionAttribute.KeyName);
                    var configureMethodType = typeof(OptionsConfigurationServiceCollectionExtensions);
                    var configureMethod = configureMethodType.GetMethods().First(x => x.Name == "Configure" && x.GetParameters().Length == 2);
                    MethodInfo method = configureMethod.MakeGenericMethod(type);
                    method.Invoke(services, new object[] {services, configurationSection});
                }
            }
        }

        private static void InjectServices(IServiceCollection services, Assembly assembly = null)
        {
            var types = ReflectionExtension.GetTypesWithAttribute<InjectAsAttribute>(assembly);
            var serviceTypeMap = new Dictionary<ServiceLifetime, Action<Type, Type>>
            {
                [ServiceLifetime.Singleton] = (type, implementedInterface) => services.AddSingleton(implementedInterface ?? type, type),
                [ServiceLifetime.Transient] = (type, implementedInterface) => services.AddTransient(implementedInterface ?? type, type),
                [ServiceLifetime.Scoped] = (type, implementedInterface) => services.AddScoped(implementedInterface ?? type, type)
            };

            foreach (var type in types)
            {
                var injectAsAttribute = type.GetCustomAttribute<InjectAsAttribute>();
                if (injectAsAttribute != null)
                {
                    serviceTypeMap[injectAsAttribute.ServiceLifetime](type,  injectAsAttribute.ImplementedInterface);
                }
            }
        }

        private static void RegisterInterfaceImplementations<TInterfaceType>(IServiceCollection services,
            ServiceLifetime serviceLifetime, Assembly assembly = null)
        {
            var typeInfos = ReflectionExtension.GetInterfacesTypeInfo<TInterfaceType>(assembly);
            foreach (var typeInfo in typeInfos)
            {
                services.Add(new ServiceDescriptor(typeInfo, typeInfo, serviceLifetime));
            }
        }
    }
}
