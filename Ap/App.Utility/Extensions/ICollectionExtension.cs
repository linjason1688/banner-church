using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yozian.Extension;
using Yozian.Extension.CollectionDto;

namespace App.Utility.Extensions
{
    public static class ICollectionExtension
    {
        /// <summary>
        /// the result is considered by the source side
        /// </summary>
        /// <param name="this"></param>
        /// <param name="target"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static CollectionDifference<T> DifferFrom<T>(
            this ICollection<T> @this,
            ICollection<T> target,
            Func<T, T, bool> comparer
        )
        {
            return DifferFrom(@this, target, new GenericComparer<T>(comparer));
        }


        /// <summary>
        /// the result is considered by the source side
        /// </summary>
        /// <param name="this"></param>
        /// <param name="target"></param>
        /// <param name="comparer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static CollectionDifference<T> DifferFrom<T>(
            this ICollection<T> @this,
            ICollection<T> target,
            IEqualityComparer<T> comparer
        )
        {
            var equalItems = @this
               .Select(
                    x =>
                    {
                        var y = target.FirstOrDefault(j => comparer.Equals(x, j));

                        return null == y ? null : new CollectionDifference<T>.Difference(x, y);
                    }
                )
               .Where(x => x != null)
               .ToList();

            var sourceMissingItems = target.Except(@this, comparer)

                //.Select(x => new CollectionDifference<T>.Difference(default, x))
               .ToList();

            var targetMissingItems = @this.Except(target, comparer)

                //.Select(x => new CollectionDifference<T>.Difference(x, default))
               .ToList();

            return new CollectionDifference<T>(equalItems, sourceMissingItems, targetMissingItems);
        }


        public static void MergeDictionary<TKey, TValue>(
            this Dictionary<TKey, TValue> @this,
            Dictionary<TKey, TValue> others
        )
        {
            others
               .ForEach(
                    kv => { @this.TryAdd(kv.Key, kv.Value); }
                );
        }


        public static Dictionary<string, TValue> ConvertToCamelCaseKey<TValue>(
            this Dictionary<string, TValue> @this
        )
        {
            var dictionary = new Dictionary<string, TValue>();

            @this
               .ForEach(
                    kv => { dictionary.TryAdd(kv.Key.ToCamelCase(), kv.Value); }
                );

            return dictionary;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="outerKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="resultSelector"></param>
        /// <typeparam name="TOuter"></typeparam>
        /// <typeparam name="TInner"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector
        )
        {
            return outer
               .GroupJoin(
                    inner,
                    outerKeySelector,
                    innerKeySelector,
                    (a, b) => new
                    {
                        a,
                        b
                    }
                )
               .SelectMany(x => x.b.DefaultIfEmpty(), (x, b) => resultSelector(x.a, b));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ConvertTo<T>(this IDictionary @this)
            where T : class, new()
        {
            if (null == @this)
            {
                return null;
            }

            return JObject.FromObject(@this).ToObject<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return null == @this || !@this.Any();
        }
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionDifference<T>
    {
        /// <summary>
        /// Both exists
        /// </summary>
        public List<Difference> MatchedItems { get; }

        /// <summary>
        /// Only existing in the targets but missing in the source
        /// </summary>
        public List<T> SourceMissingItems { get; }

        /// <summary>
        /// Only Existing in the source but missing in the target
        /// </summary>
        public List<T> TargetMissingItems { get; }

        public CollectionDifference(
            List<Difference> matchedItems,
            List<T> sourceMissingItems,
            List<T> targetMissingItems
        )
        {
            this.MatchedItems = matchedItems;
            this.SourceMissingItems = sourceMissingItems;
            this.TargetMissingItems = targetMissingItems;
        }

        public class Difference
        {
            /// <summary>
            /// Source (Left)
            /// </summary>
            public T Source { get; }

            /// <summary>
            /// Target (Right)
            /// </summary>
            public T Target { get; }

            public Difference(T source, T target)
            {
                this.Source = source;
                this.Target = target;
            }
        }
    }
}
