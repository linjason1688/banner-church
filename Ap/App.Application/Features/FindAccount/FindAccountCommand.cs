using MediatR;

namespace App.Application.Features.FindAccount
{
    /// <summary>
    /// 尋找帳號請求
    /// </summary>
    public class FindAccountCommand : IRequest<FindAccountResponse>
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// aspnet_Users.UserName
        /// </summary>
        public string UserName { get; set; }
    }
}
