using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace App.Utility.Cryptos
{
    /// <summary>
    /// 
    /// </summary>
    public class HashCrypto : ICrypto
    {
        /// <inheritdoc />
        public string Encrypt(string text, string salt = "")
        {
            if (!string.IsNullOrEmpty(salt))
            {
                text = string.Join("", text.Reverse()) + salt;
            }

            var bytes = Encoding.ASCII.GetBytes(text);

            var hash = SHA512.Create().ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        /// <inheritdoc />
        public string Decrypt(string text)
        {
            throw new NotSupportedException();
        }
    }
}
