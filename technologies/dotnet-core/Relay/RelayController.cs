using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.Relay
{
	[Route("relay")]
	public class RelayController : Controller
	{
		private readonly RelayService relayService;

		public RelayController(RelayService relayService)
		{
			this.relayService = relayService;
		}

		[Route("{key}")]
		[Produces("application/json")]
		public Task<string> GetAsync(string key)
		{
			return relayService.GetKeyValueAsync(key);
		}
	}
}
