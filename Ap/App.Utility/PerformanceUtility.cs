using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace App.Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class PerformanceUtility
    {
        public static PerformanceCounter<T> Execute<T>(
            Func<T> executor
        )
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var data = executor();

            stopwatch.Stop();

            return new PerformanceCounter<T>(data, stopwatch.Elapsed);
        }

        public static async Task<PerformanceCounter<T>> ExecuteAsync<T>(
            Func<Task<T>> executor
        )
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var data = await executor();

            stopwatch.Stop();

            return new PerformanceCounter<T>(data, stopwatch.Elapsed);
        }

        public static async Task<PerformanceCounter<int>> ExecuteAsync(
            Func<Task> executor
        )
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            await executor();

            stopwatch.Stop();

            return new PerformanceCounter<int>(0, stopwatch.Elapsed);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class PerformanceCounter<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Data { get; }


        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Elapsed { get; }

        /// <summary>
        /// 
        /// </summary>
        public long ElapsedMilliseconds { get; }


        /// <summary>
        /// 
        /// </summary>
        public PerformanceCounter(T data, TimeSpan elapsed)
        {
            this.Data = data;
            this.Elapsed = elapsed;
            this.ElapsedMilliseconds = (long) elapsed.TotalMilliseconds;
        }
    }
}
