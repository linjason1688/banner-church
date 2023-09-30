using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Utility.Extensions
{
    /// <summary>
    /// </summary>
    public static class ConcurrentQueueExtension
    {
        /// <summary>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="batchSize">take out max amount each batch</param>
        /// <param name="consumer"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<int> BatchConsumeAllAsync<T>(
            this ConcurrentQueue<T> @this,
            int batchSize,
            Func<IList<T>, CancellationToken, Task> consumer,
            CancellationToken cancellationToken = default
        )
        {
            var totalCount = 0;

            while (!@this.IsEmpty)
            {
                var items = new List<T>();

                // Take out batch items to deal
                while (!@this.IsEmpty && items.Count < batchSize)
                {
                    if (@this.TryDequeue(out var item))
                    {
                        items.Add(item);
                    }
                }

                // execute
                await consumer(items, cancellationToken);

                totalCount += items.Count;
            }

            return totalCount;
        }
    }
}
