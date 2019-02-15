using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace TengoDotNetCore {
    public class Program {
        public static void Main(string[] args) {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        // 以上这个Lambda也可以用下面的写法，写成方法的形式
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
        //    return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        //}
    }
}
