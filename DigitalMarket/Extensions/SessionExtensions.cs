using Newtonsoft.Json;
using System.Text.Json;

namespace DigitalMarket.Extensions
{
    public static class SessionExtensions
    {
        //public static void SetJson<T>(this ISession session, string key, T value)
        //{
        //    session.SetString(key, JsonSerializer.Serialize<T>(value));
        //}

        //public static T? GetJson<T>(this ISession session, string key)
        //{
        //    var sessionData = session.GetString(key);
        //    return sessionData == null ? default : JsonSerializer.Deserialize<T>(sessionData);
        //}

        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
