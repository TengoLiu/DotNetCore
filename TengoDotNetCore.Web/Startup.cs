using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TengoDotNetCore.BLL.Data;
using TengoDotNetCore.Web.DI;
using TengoDotNetCore.Web.MiddleWares;

namespace TengoDotNetCore.Web
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
            #region MVC����ģ������
            //��3.0�汾������Ҫ�ڴ˴�����Mvc 2.0
            //services.AddMvc();

            //����˶Կ������� API ��ع��ܵ�֧�֣�����֧����ͼ��ҳ�� 3.0
            //services.AddControllers();

            //����˶� Razor ҳ�����С������֧�ֵ�֧�� 3.0
            //services.AddRazorPages();

            //����˶Կ�������API ��ع��ܺ���ͼ��������ҳ����֧�֡� 3.0
            //services.AddControllersWithViews(); + services.AddRazorPages() = 2.2�汾�� services.AddMvc();
            services.AddControllersWithViews();
            #endregion

            #region Cookie
            //�����������ע��һ��Ĭ�ϵ�Cookie�������ã�����Cookie�Ĺ�ͨ����
            services.Configure<CookiePolicyOptions>(options =>
            {
                /*
                 * This lambda determines whether user consent for non-essential cookies is needed for a given request.
                 * ��lambdaȷ�����������Ƿ���Ҫ�Ǳ���cookie���û�ͬ�⡣
                 * �ҵĽ��ͣ�ASP.NET CORE֧��ŷ�޳������ݱ������� (GDPR)�����ڿͻ��˴洢Cookie��Ҫ�����û���ͬ�⡣
                 * ��Ȼ�����а취�����ģ����ǿ��������������lambda��ȫ��ָ���洢Cookie�Ƿ�һ��Ҫ�����û�ͬ�⡣
                 * �����True�Ļ�����ôҪ�����û�ͬ����ܴ棻false�򲻹���ͬ�ⲻͬ�⣬���档
                 */
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #endregion

            #region Cache�������
            /*
            * ���Microsoft.Extensions.Caching.Distributed.IDistributedCache��Ĭ��ʵ��
            * ���ڴ��е���洢��Microsoft.Extensions.DependencyInjection.IServiceCollection��
            * ��Ҫ�ֲ�ʽ������ܹ����Ŀ�ܿ��԰�ȫ����Ӵ���������Ϊ���������б��һ���֣���ȷ��������һ��ʵ�ֿ��á�
            * 
            * ������⣺������ڲ����Զ������ǰѻ����ģ�鿪���ˣ������Ҫ�����Լ��ֶ�������
            *           cacheҲ��Session�Լ�����Ļ�����û�л���Ļ���������û�취�洢��Щ�����ˡ�
            *           Ĭ�ϵĻ��������ǽ�������ڱ����ڴ��С�����ָ���ض��Ļ����ṩ�߶��������ڴ����洢��������Ū�¡�
            */
            services.AddDistributedMemoryCache();
            #endregion

            #region Session
            //���Ӧ�ó���Ự״̬����ķ���
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                //����Session����Чʱ��
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                //ָ��SessionId��Cookieֻ���ɷ����ͨ��HTTP�����޸����á�
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                //ʹSession��CookieΪ����
                options.Cookie.IsEssential = true;
            });
            #endregion

            #region ���ݿ�
            //��ʼ�����ݿ�����
            var connection = Configuration.GetConnectionString("DefaultConnectionString");
            TengoDbContext.Init(services, connection);
            #endregion

            #region DI��IOC����
            //ע��ִ�����Լ���д������ע�뷽��
            services.UseTengoDI();
            #region �Լ�ע�������ע�롾�ѷ���������Ϊ�ұ�д���µ��ܹ�����������β����������ע�����
            //��������ע�������д�������ߴ�����һЩ
            //services.AddScoped(typeof(IUserService), typeof(UserService));
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ArticleBLL>();
            #endregion
            #endregion

            ///�����Զ�����ͼ��ѯ�����ÿ���ܹ������豸���������䲻ͬ����ͼ
            //services.Configure<RazorViewEngineOptions>(o => {
            //    o.ViewLocationExpanders.Add(new CustomViewLocationExpander());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                /*
                * The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                * HTTP Strict Transport Security (ͨ�����ΪHSTS) ��һ����ȫ���ܣ������������ֻ��ͨ��HTTPS���ʵ�ǰ��Դ, ��ֹHTTP��ʽ��
                * ������������ӵ����header��ʱ����һ��ʱ���ڷ��ʱ���վ����Դ������ʹ��https��ʽ�����Ĭ��ֵΪ30�졣
                */
                //app.UseHsts();
            }

            //���HTTPS�ض���Ҳ�����������HTTPS�Ļ����Զ���ת��HTTPS
            //app.UseHttpsRedirection();

            /*
            * Ϊ��ǰ����·�����þ�̬�ļ�����,���������ӳ�侲̬�ļ�Ŀ¼��Ĭ���Ǹ�Ŀ¼�µ�wwwroot���������������env.WebRootPath��
            * ���û����һ��Ļ�����̬�ļ��Ͳ���ͨ��url�����ˣ�ȫ������404�������api��Ŀ����Ҫ��̬�ļ�ӳ��Ļ������Բ�д��һ�䡣
            */
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //����ʹ�ü���д�������Զ�����м��������Ȼ��������м��ɶҲ�����ġ�
            app.UseTengoMiddleware();

            /*
            * ժҪ:
            *  Adds the Microsoft.AspNetCore.CookiePolicy.CookiePolicyMiddleware handler to
            *  the specified Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables
            *  cookie policy capabilities.
            *  
            *  ���⣺ָ��������΢���Cookie�����м��Microsoft.AspNetCore.CookiePolicy�����ڴ���һ��Cookie������
            */
            app.UseCookiePolicy();

            /*
             * ����Session�������������һ��Ļ����ڴ���HTTP�����ʱ�򣬶�дSession���ᱨ��
             * ������һ�������Cookie֮����Ϊû��Cookie�ʹ治��SessionID,Ҳ��û��Session��
             */
            app.UseSession();

            #region app.UseMvc ��3.0�����ѷ���UseMvc����Ϊʹ��app.UseEndpoints
            //��Ϊweb��Ŀ��������MVC���������Ҫ����ʹ��MVC���������һ��Ĭ�ϵ�·��
            //app.UseMvc(routes => {
            //    /*
            //     * �������������Area��·��ӳ�����
            //     * �����и�ȱ����ǣ�����û�����ϰ汾MVCһ��ָ��·�ɹ����Ӧ�������ռ䡣
            //     * ��ˣ���Ҫ����������п������϶����� [Area("areaName")] ע�͡�
            //     * ��Ȼ�����������Ŀ������ͷ����������Ŀ������ͷ��������Ļ����ͻᱨ��˵�����·��ƥ�䵽��·�ɲ�ֹһ�������磺
            //     * ԭ������ /home/index��Ȼ����˸���������Ҳ��һ��Home�������������и�index������ԭ������ǽ����������·��ָ��Ϊ
            //     * /admin/home/index���������ֱ���������õĻ�������ǲ�֪���ģ���˵����� /home/index��ʱ�򣬻������ͬʱ�ҵ��������������뷽��
            //     * Ȼ�󱨴�˵�������Դӳ�䵽�ķ�����Ψһ��
            //     */
            //    routes.MapRoute(
            //        name: "area_admin",
            //        template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AdminArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
