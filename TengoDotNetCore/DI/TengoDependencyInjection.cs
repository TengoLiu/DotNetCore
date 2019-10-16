using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TengoDotNetCore.Common.Utils.SMS;

/// <summary>
/// 全称DependencyInjection，即依赖注入。主要负责依赖注入相关的处理。
/// 2019年10月16日16:14:05
/// </summary>
namespace TengoDotNetCore.DI {

    /// <summary>
    /// 我的依赖注入处理类
    /// </summary>
    public class TeogoDI {

        /// <summary>
        /// 初始化方法
        /// </summary>
        /// <param name="services"></param>
        public static void Initialize(IServiceCollection services) {
            //短信发送者
            services.AddScoped<ISMS, DuanXinWang>();
            RegisterByPostfix(services, "BLL", RegisterType.AddScoped);
        }

        /// <summary>
        /// 说明：通过后缀注册服务
        /// 原理：我会把解决方案中指定后缀的所有类拿出来，然后遍历。
        ///       我会先遍历一遍里面的接口和抽象类，在集合里面找到它的实现类，然后装载上去。
        ///       最后剩下来没有装载过的实现类，就一一装载上去。
        /// 注意：抽象类和实现类都必须以指定的这个后缀做结尾！
        /// <param name="services">IServiceCollection</param>
        /// <param name="postfix">要注册的服务后缀</param>
        /// <param name="registerType">注册方式</param>
        public static void RegisterByPostfix(IServiceCollection services, string postfix, RegisterType registerType) {
            //获取包含当前正在执行的代码的程序集中的所有Type类型,再筛选以指定后缀结尾的类型
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.Name.EndsWith(postfix));

            //用一个字典，来标记那些类或者接口已经装载过了
            var dic = new Dictionary<Type, object>();

            /*
             * 遍历这些类，首先对接口进行处理，对每个接口寻找它的实现类并装配到IOC容器中
             * 每个接口必须有它的实现类，不然就报错！ 
             */
            foreach (var type in types) {
                //对接口和抽象类进行处理
                if (type.IsInterface || type.IsAbstract) {
                    var implement = types.FirstOrDefault(p => p.IsSubclassOf(type));
                    if (implement == null) {
                        throw new Exception(string.Format("TengoDI异常：找不到{0}的实现类！", type.FullName));
                    }
                    switch (registerType) {
                        case RegisterType.AddScoped:
                            services.AddScoped(type, implement);
                            break;
                        case RegisterType.AddSingleton:
                            services.AddSingleton(type, implement);
                            break;
                        case RegisterType.AddTransient:
                            services.AddTransient(type, implement);
                            break;
                        default:
                            throw new Exception("TengoDI异常：Service服务注册方式异常！传入了不该传的注册方式！");
                    }
                    //最后写入字典，标记一下这两个类已经处理掉了
                    dic.Add(type, 1);
                    dic.Add(implement, 1);
                }
            }

            /*
             * 然后再对剩下的没有配对的类进行处理，剩下的就是没有标记过的类了~
             * 但是这里有一点需要提一下，就是.NET Core在注册服务的时候，比如services.AddScoped<接口，实现类>只能是注册实现了接口，
             * 但是实现类如果想要额外单独使用的话是不行的，比如注册了 IUserService的实现类UserService，那么只有IUserService能用，
             * 想把UserService注入到程序中的话是不行的。
             */
            foreach (var type in types) {
                //最后把没有标记过的类装载进去，大功告成
                //由于上面已经把接口和抽象类都装载掉了，因此此处放心装载
                if (!dic.ContainsKey(type)) {
                    switch (registerType) {
                        case RegisterType.AddScoped:
                            services.AddScoped(type);
                            break;
                        case RegisterType.AddSingleton:
                            services.AddSingleton(type);
                            break;
                        case RegisterType.AddTransient:
                            services.AddTransient(type);
                            break;
                        default:
                            throw new Exception("TengoDI异常：Service服务注册方式异常！传入了不该传的注册方式！");
                    }
                }
            }
        }
    }

    /// <summary>
    /// 服务注册类型枚举
    /// </summary>
    public enum RegisterType {
        AddScoped,
        AddSingleton,
        AddTransient
    }

    /// <summary>
    /// 扩展Service注册的方法
    /// </summary>
    public static class TengoDIExtensions {
        public static IServiceCollection UseTengoDI(this IServiceCollection services) {
            TeogoDI.Initialize(services);
            return services;
        }
    }
}
