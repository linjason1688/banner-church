using System;
using System.Collections.Generic;

namespace App.Infrastructure.DevSupports
{
    /// <summary>
    /// </summary>
    public static class DataSeedingHelper
    {
        public static readonly string Creator = "seeding";


        internal static T GetRandItem<T>(this IList<T> @this)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var index = rnd.Next(0, @this.Count - 1);

            return @this[index];
        }
    }
}
