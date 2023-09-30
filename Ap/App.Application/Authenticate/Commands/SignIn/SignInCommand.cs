#region

using App.Application.Authenticate.Dtos;
using MediatR;

#endregion

namespace App.Application.Authenticate.Commands.SignIn
{
    /// <summary>
    /// </summary>
    public class SignInCommand : IRequest<SignInResponse>
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 驗證碼
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// 驗證碼 Token
        /// </summary>
        public string VerificationToken { get; set; }
    }
}
