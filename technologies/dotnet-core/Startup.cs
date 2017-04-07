using System.Collections.Generic;
using DotNetCore.Contacts;
using DotNetCore.Relay;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetCore
{
	public class Startup
	{
		private readonly IConfigurationRoot configuration;

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.AddInMemoryCollection(DefaultConfiguration)
				.AddEnvironmentVariables();

			configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Relay
			services.AddSingleton<RelayService>();

			// Contacts
			services.AddSingleton<ContactRepository>();

			// Shared
			services.AddSingleton<IConfiguration>(configuration);

			// Framework
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseMvc();
		}

		private static Dictionary<string, string> DefaultConfiguration
		{
			get
			{
				return new Dictionary<string, string>
            	{
					{ "Relay:KeyValueServiceHostname", "localhost"},
					{ "Relay:KeyValueServicePort", "8080"},
					{ "Contacts:DatabaseHost", "localhost"},
					{ "Contacts:DatabaseName", "web_server_tech_benchmarks" },
                	{ "Contacts:DatabaseUsername", "postgres"},
                	{ "Contacts:DatabasePassword", "password"}
            	};
			}
		}
	}
}
