using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }

    }
}
