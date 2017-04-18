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
		public async Task<KeyValuePair> GetAsync(string key)
		{
			var keyValue = await relayService.GetKeyValueAsync(key);
			
			return new KeyValuePair
			{
				Key = key,
				Value = keyValue.Value
			};
		}
	}
}
