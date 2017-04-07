using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Echo
{
	[Route("echo")]
	public class EchoController : Controller
	{
		[Route("{text}")]
		public string Get(string text)
		{
			return text;
		}
	}
}
