using System;
using System.Collections.Generic;
using System.Reflection;
using App.Utility.Attributes;
using Yozian.Extension;

namespace App.Utility.Extensions
{
    /// <summary>
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string ToJson(this object @this, bool useCamelcase = true, bool formatted = false)
        {
            return Serialization.Serialize(@this, useCamelcase, formatted);
        }

        /// <summary>
        /// support nested type dump
        /// </summary>
        public static Dictionary<string, object> ToDictionary(
            this object @this,
            bool useCamelCase = false,
            bool useHashProperty = false
        )
        {
            var hash = new Dictionary<string, object>();

            @this.GetType()
               .GetProperties()
               .ForEach(
                    pi =>
                    {
                        var key = useCamelCase ? pi.Name.ToCamelCase() : pi.Name;
                        var val = pi.GetValue(@this, null);

                        // 採用 HashProperty
                        if (useHashProperty)
                        {
                            var attr = pi.GetCustomAttribute<HashProperty>();

                            // 限有 property 者
                            if (null == attr)
                            {
                                return;
                            }

                            key = attr?.Name ?? key;

                            // 指定 default 值
                            if (null == val && null != attr?.NullAlternateValue)
                            {
                                val = attr.NullAlternateValue;
                            }
                        }

                        var t = val?.GetType();

                        // not primitive type should recursive transform
                        if (null != t && !(t.IsPrimitive || t.IsValueType || t == typeof(string)))
                        {
                            val = val.ToDictionary(useCamelCase, useHashProperty);
                        }

                        hash.Add(key, val);
                    }
                );

            return hash;
        }


        /// <summary>
        /// only for first level type dump
        /// </summary>
        /// <param name="this"></param>
        /// <param name="valueConverter"></param>
        /// <param name="useCamelCase"></param>
        /// <param name="useHashProperty"></param>
        /// <returns></returns>
        public static Dictionary<string, TValue> ToDictionary<TValue>(
            this object @this,
            Func<object, TValue> valueConverter,
            bool useCamelCase = false,
            bool useHashProperty = true
        )
        {
            var hash = new Dictionary<string, TValue>();

            @this.GetType()
               .GetProperties()
               .ForEach(
                    pi =>
                    {
                        var key = useCamelCase ? pi.Name.ToCamelCase() : pi.Name;
                        var val = pi.GetValue(@this, null);

                        // 採用 HashProperty
                        if (useHashProperty)
                        {
                            var attr = pi.GetCustomAttribute<HashProperty>();

                            // 限有 property 者
                            if (null == attr)
                            {
                                return;
                            }

                            key = attr?.Name ?? key;

                            // 指定 default 值
                            if (null == val && null != attr?.NullAlternateValue)
                            {
                                val = attr.NullAlternateValue;
                            }
                        }

                        var value = valueConverter(val);
                        hash.Add(key, value);
                    }
                );

            return hash;
        }
    }
}
