using MediatR;

namespace App.Application.Features.UpdatePassword
{
    /// <summary>
    /// 修改密碼
    /// </summary>
    public class UpdatePasswordCommand : IRequest<UpdatePasswordCommandResponse>
    {
        public long UserId { get; set; }

        /// <summary>
        /// 新密碼
        /// </summary>
        public string Password { get; set; }
    }
}
