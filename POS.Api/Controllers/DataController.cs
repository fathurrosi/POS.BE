using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.Api.Controllers
{   

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowedOrigins")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            // Return data
            return Ok(new { message = "Hello, World!" });
        }
    }

}
