using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DotNetCore.Relay
{
    public class RelayService
	{
		private readonly HttpClient client;

		public RelayService(IConfiguration configuration)
		{
			var hostname = configuration["Relay:KeyValueServiceHostname"];
			var port = configuration["Relay:KeyValueServicePort"];

			client = new HttpClient
			{
				BaseAddress = new Uri($"http://{hostname}:{port}")
			};
		}

		public async Task<KeyValue> GetKeyValueAsync(string key)
		{
			var response = await client.GetAsync($"/store/{key}");
			return await response.Content.ReadAsAsync<KeyValue>();
		}
	}
}
