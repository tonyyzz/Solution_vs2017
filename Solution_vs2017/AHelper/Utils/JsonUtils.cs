using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auction.Utility.Utils
{
    public static class JsonUtils
    {
        /// <summary>
        /// string-json to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// object to string-json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        ///  string-json to jobject
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject DeserializeObject(string json)
        {
            return JObject.Parse(json);
        }

    
    }
}
