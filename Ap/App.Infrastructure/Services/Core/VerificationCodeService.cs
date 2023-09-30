using System.Threading.Tasks;
using App.Application.Common.Interfaces.Services.Core;
using App.Infrastructure.Dtos.WebApis;
using Yozian.DependencyInjectionPlus.Attributes;

namespace App.Infrastructure.Services.Core
{
    [SingletonService]
    public class VerificationCodeService
    {
        private readonly IVerifyService verifyService;

        public VerificationCodeService(
            IVerifyService verifyService
        )
        {
            this.verifyService = verifyService;
        }

        public async Task<VerificationCodeResponse> CreateVerificationCode()
        {
            var code = await this.verifyService.CreateVerification();
            return new VerificationCodeResponse()
            {
#if DEBUG
                Code = code.Code,
#endif
                Image = code.Image,
                Token = code.Token
            };
        }
    }
}
