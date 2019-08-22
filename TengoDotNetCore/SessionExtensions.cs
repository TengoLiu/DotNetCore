using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TengoDotNetCore {
    /// <summary>
    /// 扩展Session操作的方法，使之可以存取对象
    /// </summary>
    public static class SessionExtensions {
        public static void Set<T>(this ISession session, string key, T value) {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key) {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
