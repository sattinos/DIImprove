using System;
using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using DIImprove.Configurations;
using DIImprove.Services;
using DIImprove.Services.Interfaces;
using DIImproveUnitTests.Setup;

namespace DIImproveUnitTests
{
    public class DependencyInjectionTest : IClassFixture<TestFactory>
    {
        private readonly TestFactory _testFactory;
        private readonly AppSettings _appSettings;
        private readonly ServiceA _serviceA;
        private ServiceB _serviceB;
        private readonly ServiceC _serviceC;

        public DependencyInjectionTest(TestFactory testFactory)
        {
            _testFactory = testFactory;
            _appSettings = testFactory.Server.Services.GetService<IOptions<AppSettings>>()?.Value;
            _serviceA = testFactory.Server.Services.GetService<ServiceA>();
            // ServiceB is scoped one. It can't be resolved from the "Root" container.
            // We will resolve it later in a local scope
            _serviceC = testFactory.Server.Services.GetService<ServiceC>();
        }

        [Fact(DisplayName = "Strongly typed configuration section must be registered and final values must be overriden.")]
        public void VerifyRegisteredConfigurationSection()
        {
            _appSettings.Should().NotBeNull();
            _appSettings.Name.Should().Be("Dependency Injection Improvements");
            _appSettings.IsLegacy.Should().BeTrue(); // The value should be overriden from appsettings.IntegrationTest.json
            _appSettings.Handles.Should().Be(50);
        }

        [Fact(DisplayName = "Resolving Singleton or Transient services must succeed from the constructor")]
        public void VerifyInjectedServices()
        {
            _serviceA.Should().NotBeNull();
            _serviceC.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should throw exception if tried to resolve scoped service from the 'root' container")]
        public void VerifyResolvingScopedServicesFailureFromRootContainer()
        {
            Exception ex = null;
            try
            {
                _serviceB = _testFactory.Server.Services.GetService<ServiceB>();
            }
            catch (Exception e)
            {
                ex = e;
            }

            ex.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should resolve scoped service from local scope successfully")]
        public void VerifyResolvingScopedServicesSuccessLocallyCreatedContainer()
        {
            Exception ex = null;
            try
            {
                using (var scope = _testFactory.Services.CreateScope())
                {
                    _serviceB = scope.ServiceProvider.GetService<ServiceB>();
                    _serviceB.Should().NotBeNull();
                }
            }
            catch (Exception e)
            {
                ex = e;
            }

            ex.Should().BeNull();
        }
        
        [Fact(DisplayName = "Should get all implementation of ISerializableInterface")]
        public void ShouldGetAllImplementationSuccessfully()
        {
            var implementations = _testFactory.Services.GetServices<ISerializable>().ToArray();
            implementations.Should().NotBeNull();
            implementations.Count().Should().Be(2);
        }
    }
}