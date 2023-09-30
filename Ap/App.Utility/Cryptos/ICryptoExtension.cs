using System.Security.Cryptography;
using System.Text;
using System;

namespace App.Utility.Cryptos
{
    public static class ICryptoExtension
    {
        private static readonly string encryptHintPrefix = "X-ENC:";

        public static string CompatibleEncrypt(this ICrypto @this, string text)
        {
            return encryptHintPrefix + @this.Encrypt(text);
        }

        public static string CompatibleDecrypt(this ICrypto @this, string text, string salt = "")
        {
            if (!text.StartsWith(encryptHintPrefix))
            {
                return text;
            }

            text = text.Replace(encryptHintPrefix, "");

            return @this.Decrypt(text);
        }

        public static string GenerateSalt(this ICrypto @this, int length = 10)
        {
            return RandomUtility.GenerateRandomText(length);
        }

        public static string EncodePassword(this ICrypto @this, string pass, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            //byte[] src = Encoding.Unicode.GetBytes(salt); Corrected 5/15/2013
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);


        }
    }
}
