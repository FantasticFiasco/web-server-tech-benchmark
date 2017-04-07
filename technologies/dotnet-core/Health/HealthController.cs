using Microsoft.AspNetCore.Mvc;

[Route("health")]
public class HealthController : Controller
{
		public IActionResult Get()
		{
			return NoContent();
		}
}