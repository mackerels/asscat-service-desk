using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Internal;
using SD.Storage;

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