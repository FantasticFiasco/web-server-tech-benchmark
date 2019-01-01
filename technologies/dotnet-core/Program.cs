using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:8090/")
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.Sources.Clear();

                    config
                        .AddInMemoryCollection(DefaultConfiguration)
                        .AddEnvironmentVariables();
                })
                .Build();

        private static Dictionary<string, string> DefaultConfiguration =>
            new Dictionary<string, string>
            {
                { "Relay_KeyValueServiceHostname", "localhost"},
                { "Relay_KeyValueServicePort", "8080"},
                { "Contacts_DatabaseHost", "localhost"},
                { "Contacts_DatabaseName", "web_server_tech_benchmarks" },
                { "Contacts_DatabaseUsername", "postgres"},
                { "Contacts_DatabasePassword", "password"}
            };
    }
}
