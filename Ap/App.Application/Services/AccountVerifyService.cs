using System;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services.Core;
using App.Utility;
using App.Utility.Cryptos;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Application.Services
{
    [ScopedService]
    public class AccountVerifyService
    {
        private const string key = "app.auth.image@verification.ZXCV";

        // 16 bytes
        private const string iv = "verify.code@iv.Z";

        private readonly ICrypto crypto;
        private readonly IDateTime dateTime;

        public AccountVerifyService(IDateTime dateTime)
        {
            this.dateTime = dateTime;
            this.crypto = new AesCrypto(key, iv);
        }

        public Task<AccountVerification> CreateVerification(string code, CancellationToken cancellationToken = default)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var stamp = new VerifyStamp()
                    {
                        Code = code,
                        CreateAt = this.dateTime.Now
                    };

                    var json = Serialization.Serialize(stamp);

                    return new AccountVerification()
                    {
#if DEBUG
                        Code = code,
#endif
                        Token = this.crypto.CompatibleEncrypt(json)
                    };
                },
                cancellationToken
            );
        }

        /// <summary>
        /// </summary>
        /// <param name="code"></param>
        /// <param name="token"></param>
        /// <exception cref="MyBusinessException"></exception>
        public void Verify(string code, string token)
        {
            try
            {
                var json = this.crypto.CompatibleDecrypt(token);
                var stamp = Serialization.Deserialize<VerifyStamp>(json);

                if (code != stamp.Code)
                {
                    throw new MyBusinessException("驗證碼錯誤！");
                }

                if ((this.dateTime.Now - stamp.CreateAt).TotalMinutes > 1.0f)
                {
                    throw new MyBusinessException("驗證碼已逾期，請刷新！", "B0002");
                }
            }
            catch (MyBusinessException)
            {
                throw;
            }
            catch (Exception)
            {
                // we dont care what happened here
                throw new MyBusinessException("驗證碼錯誤！");
            }
        }

        private class VerifyStamp
        {
            public string Code { get; set; }

            public DateTime CreateAt { get; set; }
        }
    }
}
