using System;
using System.Linq;
using System.Security.Cryptography;
using Yozian.Extension;

namespace App.Utility
{
    /// <summary>
    /// </summary>
    public static class RandomUtility
    {
        public static int GenerateRandomInteger(int minVal = 0, int maxVal = 100)
        {
            var rnd = new byte[4];
            using var rng = new RNGCryptoServiceProvider();

            rng.GetBytes(rnd);

            var i = Math.Abs(BitConverter.ToInt32(rnd, 0));

            return Convert.ToInt32(i % (maxVal - minVal + 1) + minVal);
        }

        public static string GenerateRandomText(int length, string samples = null)
        {
            if (string.IsNullOrEmpty(samples))
            {
                samples = Enumerable.Range(0, 26)
                   .Select(i => (char) ('a' + i))
                   .FlattenToString()
                   .ToUpper();
            }

            var rnd = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(rnd);
            }

            var sampleChars = samples.ToCharArray();
            var samplesLength = sampleChars.Length;

            return Enumerable
               .Range(0, length)
               .Select(i => sampleChars[rnd[i] % samplesLength])
               .FlattenToString();
        }
    }
}
