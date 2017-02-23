using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace service_desk
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