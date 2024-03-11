// Ваш код контроллера

using Evg.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Evg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataBaseController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public DataBaseController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetConnectionString()
        {

            return Ok(new { _appSettings?.DbCnStr });



        }
    }
}
