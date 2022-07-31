using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DIImprove.Configurations;
using DIImprove.Services;
using DIImprove.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DIImprove.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ServiceA _serviceA;
        private readonly ServiceB _serviceB;
        private readonly ServiceC _serviceC;
        private readonly IServiceProvider _serviceProvider;
        private readonly AppSettings _appSettings;

        public HomeController(ServiceA serviceA, ServiceB serviceB, ServiceC serviceC, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
        {
            _serviceA = serviceA;
            _serviceB = serviceB;   // ServiceB (scoped service) has been successfully resolved because it is fetched in lifetime of the request connection 
            _serviceC = serviceC;
            _serviceProvider = serviceProvider;
            _appSettings = appSettings.Value;
        }
        
        [HttpGet]
        public string Index()
        {
            var implementations = _serviceProvider.GetServices<ISerializable>();
            return $@"DI Improvements: urlOrArticle

{_serviceA.DoSomething()}
{_serviceB.DoSomething()}
{_serviceC.DoSomething()}
{_appSettings}
count of ISerializable implementations = {implementations.Count()}
";
        }
    }
}