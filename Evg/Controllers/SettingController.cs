using Evg.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Evg.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SettingController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public SettingController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(_appSettings?.DbCnStr);
            return Ok(new { _appSettings?.DbCnStr });
        }
    }
}