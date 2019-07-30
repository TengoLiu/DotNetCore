using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TengoDotNetCore {
    public class Program {
        public static void Main(string[] args) {
            var host = CreateWebHostBuilder(args).Build();

            #region 如果需要在Main启动方法的时候获取注册好的服务的话，可以这么写
            //using (var serviceScope = host.Services.CreateScope()) {
            //    var services = serviceScope.ServiceProvider;

            //    try {
            //       //这里就可以获取注册的服务
            //        var serviceContext = services.GetRequiredService<MyService>();
            //        // Use the context here
            //    }
            //    catch (Exception ex) {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred.");
            //    }
            //}
            #endregion

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

        // 以上这个Lambda也可以用下面的写法，写成方法的形式
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
        //    return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        //}
    }
}
