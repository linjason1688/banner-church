#region

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yozian.Extension;

#endregion

namespace App.Utility.Json
{
    public static class JsonMerger
    {
        private static readonly JsonMergeSettings mergeSettings = new JsonMergeSettings
        {
            MergeArrayHandling = MergeArrayHandling.Union,
            MergeNullValueHandling = MergeNullValueHandling.Ignore
        };

        public static string MergeObjects(object rootObject, params object[] others)
        {
            if (null == rootObject)
            {
                throw new ArgumentException($"{nameof(rootObject)} cant not be null!");
            }

            var root = JObject.FromObject(rootObject);

            others.Where(x => null != x)
               .ForEach(x => root.Merge(JObject.FromObject(x)));

            return root.ToString(Formatting.None);
        }
    }
}
