#pragma warning disable CA1416

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Common.Dtos.Services;
using App.Application.Common.Exceptions;
using App.Application.Common.Interfaces.Services.Core;
using App.Utility;
using App.Utility.Cryptos;
using App.Utility.Extensions;
using Yozian.DependencyInjectionPlus.Attributes;
using Yozian.Extension;

namespace App.Infrastructure.Services.Core
{
    /// <summary>
    /// </summary>
    [TransientService(typeof(IVerifyService))]
    public class VerifyService : IVerifyService
    {
        // 32 bytes
        private const string key = "app.auth.image@verification.ZXCV";

        // 16 bytes
        private const string iv = "verify.code@iv.Z";

        private readonly ICrypto crypto;
        private readonly IDateTime dateTime;

        public VerifyService(IDateTime dateTime)
        {
            this.dateTime = dateTime;
            this.crypto = new AesCrypto(key, iv);
        }


        public Task<Verification> CreateVerification(int codeLength = 4, CancellationToken cancellationToken = default)
        {
            return Task.Factory.StartNew(
                () =>
                {
                    var min = (int) Math.Pow(10, codeLength - 1);
                    var max = (int) Math.Pow(10, codeLength) - 1;

                    var code = RandomUtility.GenerateRandomInteger(min, max);

                    var img = drawImage(code.ToString());

                    var stamp = new VerifyStamp()
                    {
                        Code = code.ToString(),
                        CreateAt = this.dateTime.Now
                    };

                    var json = Serialization.Serialize(stamp);

                    return new Verification
                    {
#if DEBUG
                        Code = code,
#endif
                        Image = img.ToBase64(),
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
                    throw new MyBusinessException("驗證碼已逾期，請刷新！");
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


        private static Bitmap drawImage(string code)
        {
            // insert spaces between characters
            var text = string.Join(" ", code.ToArray());
            var font = new Font("Arial", 25, FontStyle.Regular);

            var image = new Bitmap(120, 50);

            var g = Graphics.FromImage(image);
            var textSize = g.MeasureString(text, font).ToSize();

            // reconstruct
            var xPadding = 10;
            image = new Bitmap(textSize.Width + xPadding, textSize.Height);
            g = Graphics.FromImage(image);

            //清空圖片背景色
            g.Clear(Color.Azure);

            int rndRgbVal() => 10 + DateTime.Now.Millisecond % 105;

            var brush = new LinearGradientBrush(
                new Rectangle(
                    0,
                    0,
                    textSize.Width,
                    textSize.Height
                ),
                Color.FromArgb(rndRgbVal(), rndRgbVal(), rndRgbVal()),
                Color.FromKnownColor(KnownColor.DarkRed),
                1.5F,
                true
            );

            g.DrawString(text, font, brush, Convert.ToInt32(xPadding / 2), 0);

            var random = new Random(Guid.NewGuid().GetHashCode());

            Enumerable
               .Range(0, 10)
               .ForEach(
                    i =>
                    {
                        //畫圖片的前景噪音點
                        var x = random.Next(image.Width);
                        var y = random.Next(image.Height);

                        image.SetPixel(x, y, Color.FromArgb(random.Next()));
                    }
                );

            //畫圖片的邊框線
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            return image;
        }
    }


    internal class VerifyStamp
    {
        public string Code { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
