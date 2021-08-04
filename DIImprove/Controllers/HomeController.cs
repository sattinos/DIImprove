using Microsoft.AspNetCore.Mvc;

namespace DIImprove.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return $"DI Improvements: urlOrArticle";
        }
    }
}