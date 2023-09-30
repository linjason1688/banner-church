using MediatR;

namespace App.Application.Features.SendVerificationCode
{
    /// <summary>
    /// 
    /// </summary>
    public class SendVerificationCodeRequest : IRequest<SendVerificationCodeResponse>
    {
        /// <summary>
        /// Email 或 手機號碼
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// Email 或 SMS 驗證
        /// </summary>
        public PasswordResetType ResetType { get; set; }
    }
}
