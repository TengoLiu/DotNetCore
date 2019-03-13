using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TengoDotNetCore.Data;
using TengoDotNetCore.Service;
using TengoDotNetCore.Service.Impl;

namespace TengoDotNetCore {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        //项目配置对象
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            //这个方法用于注入一个默认的Cookie策略配置，配置Cookie的共通属性
            services.Configure<CookiePolicyOptions>(options => {
                /*
                 * This lambda determines whether user consent for non-essential cookies is needed for a given request.
                 * 此lambda确定给定请求是否需要非必需cookie的用户同意。
                 * 我的解释：ASP.NET CORE支持欧洲常规数据保护法规 (GDPR)，即在客户端存储Cookie需要经过用户的同意。
                 * 当然，是有办法跳过的，我们可以设置下面这个lambda，全局指定存储Cookie是否一定要经过用户同意。
                 * 如果是True的话，那么要经过用户同意才能存；false则不管你同意不同意，都存。
                 */
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            /*
             * 添加Microsoft.Extensions.Caching.Distributed.IDistributedCache的默认实现
             * 将内存中的项存储到Microsoft.Extensions.DependencyInjection.IServiceCollection。
             * 需要分布式缓存才能工作的框架可以安全地添加此依赖项作为其依赖项列表的一部分，以确保至少有一个实现可用。
             * 
             * 个人理解：框架现在不会自动给我们把缓存的模块开启了，因此需要我们自己手动开启。
             *           cache也是Session以及缓存的基础，没有缓存的话，根本就没办法存储这些数据了。
             *           默认的缓存设置是将缓存存在本机内存中。可以指定特定的缓存提供者而不是用内存来存储，后面再弄下。
             */
            services.AddDistributedMemoryCache();

            //添加应用程序会话状态所需的服务。
            services.AddSession(options => {
                // Set a short timeout for easy testing.
                //设置Session的有效时间
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                //指定SessionId的Cookie只能由服务端通过HTTP请求修改设置。
                options.Cookie.HttpOnly = true;
            });

            //用于在Microsoft.Extensions.DependencyInjection.ISeviceCollection中设置MVC服务的扩展方法。
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //初始化数据库配置
            var connection = Configuration.GetConnectionString("DefaultConnectionString");
            //然后注册DbContext到容器中，后面如果哪个地方要使用的话，就能直接给其注入了
            services.AddDbContext<TengoDbContext>(options => {
                //官方说明：在查询中使用row_number（）而不是offset/fetch。此方法向后兼容到SQL Server 2005。
                //第二个参数如果不写，那么如果是SQLSERVER2008的话，skip.take分页将无法使用，会有兼容问题
                options.UseSqlServer(connection, a => a.UseRowNumberForPaging());
            });


            #region 自己注册的依赖注入
            //配置依赖注入的两种写法，后者代码简洁一些
            //services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleCategoryService, ArticleCategoryService>();
            services.AddScoped<IGoodsService, GoodsService>();
            services.AddScoped<IGoodsCategoryService, GoodsCategoryService>();
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// 此方法有运行时调用。使用此方法配置HTTP请求管道。
        /// 个人理解：这个方法是用来对请求刚进来的时候要做的处理所做的设置。
        /// 比如可以配置当HTTP请求进来的时候，如果发现是HTTP请求，就给你跳转到HTTPS。
        /// </summary>
        /// <param name="app">定义一个类，该类提供配置应用程序请求管道的机制。</param>
        /// <param name="env">提供有关运行应用程序的Web宿主环境的信息。
        /// env.WebRootPath ：web虚拟路径的静态目录根路径，默认为项目下的wwwroot文件夹。因为现在的web项目不仅仅是MVC!
        /// env.ContentRootPath：代码的根目录，也就是我们项目的根目录。
        /// env.IsDevelopment()：主要是用来判断当前项目是设置为什么环境的，比如开发环境Development、分阶段环境Staging、生产环境Production
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            //判断是开发环境还是生产环境
            if (env.IsDevelopment()) {
                //如果是生产环境的话，就使用报错信息详情页，直接把错误显示出来
                app.UseDeveloperExceptionPage();
            }
            else {
                //如果是生产环境，不能把报错信息给客户看，因此设置报错的时候重定向的地址
                app.UseExceptionHandler("/Home/Error");

                /*
                 * The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 * HTTP Strict Transport Security (通常简称为HSTS) 是一个安全功能，它告诉浏览器只能通过HTTPS访问当前资源, 禁止HTTP方式。
                 * 告诉浏览器当接到这个header的时候，在一定时间内访问本网站的资源都必须使用https方式。这个默认值为30天。
                 */
                app.UseHsts();
            }

            //添加HTTPS重定向，也就是如果不是HTTPS的话会自动跳转到HTTPS
            app.UseHttpsRedirection();

            /*
             * 为当前请求路径启用静态文件服务,即对外可以映射静态文件目录，默认是根目录下的wwwroot，这个可以在设置env.WebRootPath。
             * 如果没有这一句的话，静态文件就不能通过url访问了，全部都是404。如果是api项目不需要静态文件映射的话，可以不写这一句。
             */
            app.UseStaticFiles();

            /*
             * 摘要:
             *  Adds the Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware handler to
             *  the specified Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables
             *  cookie policy capabilities.
             *  
             *  大意：指定并启用微软的Cookie策略中间件Microsoft.AspNetCore.CookiePolicy，用于处理一切Cookie的问题
             */
            app.UseCookiePolicy();

            /*
             * 启用Session，如果不配置这一句的话，在处理HTTP请求的时候，读写Session都会报错！
             * 而且这一句必须在Cookie之后，因为没有Cookie就存不了SessionID,也就没有Session！
             */
            app.UseSession();

            //因为web项目不仅仅是MVC！因此这里要配置使用MVC，并且添加一个默认的路由
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                /*
                 * 这里添加了区域Area的路由映射规则。
                 * 但是有个缺点就是，这里没法像老版本MVC一样指定路由规则对应的命名空间。
                 * 因此，需要在区域的所有控制器上都加上 [Area("areaName")] 注释。
                 * 不然如果区域里面的控制器和方法跟最外层的控制器和方法重名的话，就会报错说请求的路径匹配到的路由不止一个，比如：
                 * 原本有了 /home/index，然后加了个区域，里面也有一个Home控制器，并且有个index方法，原本想的是将区域里面的路由指定为
                 * /admin/home/index。但是如果直接这样设置的话，框架是不知道的，因此当请求 /home/index的时候，会帮我们同时找到这两个控制器与方法
                 * 然后报错说请求的资源映射到的方法不唯一。
                 */
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
