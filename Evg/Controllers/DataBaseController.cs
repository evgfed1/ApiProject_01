using Evg.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Evg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataBaseController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DataBaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("connectionString")]
        public IActionResult GetConnectionString()
        {
            string dbConnectionString = _configuration.GetConnectionString("DbCnStr");

            return Ok(new { ConnectionStrings = dbConnectionString });
        }
    }
}
