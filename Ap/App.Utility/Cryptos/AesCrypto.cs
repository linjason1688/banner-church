#region

using System;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace App.Utility.Cryptos
{
    /// <summary>
    /// Instance 則使用預設 key and iv
    /// 使用非 default key and iv 可自行創建 instance
    /// </summary>
    public class AesCrypto : ICrypto
    {
        // 32 bytes
        private static readonly string defaultKey = "app.api@secret-erdfcvyuhjnm00000";

        // 16 bytes
        private static readonly string defaultKeyIv = "sApp.iv@vector-0";

        private static readonly Lazy<AesCrypto> instance =
            new Lazy<AesCrypto>(() => new AesCrypto(defaultKey, defaultKeyIv));

        private readonly string iv;
        private readonly string key;

        public static AesCrypto Instance => instance.Value;

        /// <summary>
        /// </summary>
        /// <param name="key">32 bytes</param>
        /// <param name="iv">16 bytes</param>
        public AesCrypto(string key, string iv)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(iv))
            {
                throw new ArgumentException("key and iv should not be null or empty!");
            }

            this.key = key;
            this.iv = iv;
        }

        public string Encrypt(string text, string salt = "")
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var bytes = Encoding.UTF8.GetBytes(text);
            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(this.key);
            aes.IV = Encoding.UTF8.GetBytes(this.iv);
            var transform = aes.CreateEncryptor();

            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }

        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var encryptBytes = Convert.FromBase64String(text);
            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = Encoding.UTF8.GetBytes(this.key);
            aes.IV = Encoding.UTF8.GetBytes(this.iv);
            var transform = aes.CreateDecryptor();

            return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));
        }
    }
}
