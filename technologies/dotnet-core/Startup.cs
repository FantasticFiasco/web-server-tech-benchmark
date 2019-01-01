using DotNetCore.Contacts;
using DotNetCore.Relay;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
		{
			// Relay
			services.AddSingleton<RelayService>();

			// Contacts
			services.AddSingleton<ContactRepository>();

			// Framework
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}
