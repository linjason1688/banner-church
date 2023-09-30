using App.Application.Features.SendVerificationCode;
using MediatR;

namespace App.Application.Features.ResetPassword
{
    /// <summary>
    /// 註冊
    /// </summary>
    public class ResetPasswordCommand : IRequest<ResetPasswordCommandResponse>
    {
        public string account { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Old
        /// </summary>
        public string OldPassword { get; set; }

        public string CellPhone { get; set; }
        public string Email1 { get; set; }
        public PasswordResetType ResetType { get; set; }
    }
}
