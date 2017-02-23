using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Path.Combine(Directory.GetCurrentDirectory(), "frontend"))
                .UseStartup<Startup>()
                .UseUrls("http://localhost:22022")
                .Build();

            host.Run();
        }
    }
}