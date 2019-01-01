using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Health
{
    [Route("health")]
    public class HealthController : Controller
    {
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}
