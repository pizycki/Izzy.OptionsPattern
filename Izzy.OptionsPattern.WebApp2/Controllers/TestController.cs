using System.Threading.Tasks;
using Izzy.OptionsPattern.WebApp1.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Izzy.OptionsPattern.WebApp1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public TestController(IOptionsSnapshot<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_appSettings.ServiceName);
        }
    }
}