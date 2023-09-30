#region

using System;
using App.Utility.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

#endregion

namespace App.Utility
{
    public static class Serialization
    {
        private static readonly JsonSerializerSettings defaultConfig = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.None
        };

        private static readonly JsonSerializerSettings camelCaseConfig = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.None,
            ContractResolver = new MyCamelCaseResolver()
        };

        private static readonly JsonSerializerSettings defaultFormattedConfig = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.Indented
        };

        private static readonly JsonSerializerSettings camelCaseFormattedConfig = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.Indented,
            ContractResolver = new MyCamelCaseResolver()
        };

        static Serialization()
        {
            defaultConfig.Converters.Add(new StringEnumConverter());
            camelCaseConfig.Converters.Add(new StringEnumConverter());
            defaultFormattedConfig.Converters.Add(new StringEnumConverter());
            camelCaseFormattedConfig.Converters.Add(new StringEnumConverter());
        }

        public static string Serialize(object data, bool useCamelCase = true, bool formatted = true)
        {
            if (formatted)
            {
                return JsonConvert.SerializeObject(
                    data,
                    useCamelCase ? camelCaseFormattedConfig : defaultFormattedConfig
                );
            }

            return JsonConvert.SerializeObject(data, useCamelCase ? camelCaseConfig : defaultConfig);
        }

        public static T Deserialize<T>(string json, bool useCamelCase = true)
        {
            if (string.IsNullOrEmpty(json))
            {
                json = "{}";
            }

            return JsonConvert.DeserializeObject<T>(json, useCamelCase ? camelCaseConfig : defaultConfig);
        }

        public static T Deserialize<T>(Type type, string json, bool useCamelCase = true)
            where T : class
        {
            if (typeof(T).FullName != type.FullName)
            {
                throw new ArgumentException($"Type mismatched: {typeof(T).FullName} v.s. {type.FullName}");
            }

            if (string.IsNullOrEmpty(json))
            {
                json = "{}";
            }

            return JsonConvert.DeserializeObject(json, type, useCamelCase ? camelCaseConfig : defaultConfig) as T;
        }

        public static object Deserialize(Type type, string json, bool useCamelCase = true)
        {
            if (string.IsNullOrEmpty(json))
            {
                json = "{}";
            }

            return JsonConvert.DeserializeObject(json, type, useCamelCase ? camelCaseConfig : defaultConfig);
        }


        public static TTarget Convert<TTarget>(object data)
        {
            return JObject.FromObject(data).ToObject<TTarget>();
        }
    }
}
