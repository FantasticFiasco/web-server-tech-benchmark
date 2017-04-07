using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:8090/")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
