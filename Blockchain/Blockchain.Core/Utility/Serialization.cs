using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blockchain.Core.Utility
{
    public static class Serialization
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string GenerateUniqueString(List<object> objetos)
        {
            var stringConcat = string.Empty;

            foreach (var item in objetos)
                stringConcat += item.ToJson();

            return stringConcat;
        }
    }
}
