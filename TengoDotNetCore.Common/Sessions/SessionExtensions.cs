using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TengoDotNetCore.Common.Sessions {
    /// <summary>
    /// 扩展Session操作的方法，使之可以存取对象
    /// </summary>
    public static class SessionExtensions {

        /// <summary>
        /// Session的Set扩展方法，使Session能够存放对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key">key</param>
        /// <param name="value">值</param>
        public static void Set<T>(this ISession session, string key, T value) {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// Session的Set扩展方法，使Session能够读取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key">key</param>
        public static T Get<T>(this ISession session, string key) {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
