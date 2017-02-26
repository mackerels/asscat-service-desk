using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Internal;
using service_desk.Storage;

namespace SD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DescStorage().Agents.ToList().ForEach(a=> Console.WriteLine(string.Format("{0}, {1}", a.Name, a.Login)));
            new DescStorage().Companies.ToList().ForEach(c=> Console.WriteLine(string.Format("{0}", c.Name)));
            new DescStorage().Issues.ToList().ForEach(r=> Console.WriteLine(string.Format("{0}", r.Theme, r.Matter)));


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