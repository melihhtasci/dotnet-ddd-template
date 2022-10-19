using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    public class InfoController : ApiController
    {

        [HttpGet]
        public IActionResult getInfo()
        {
            return Ok("Weather is great today, right?");
        }

    }
}
