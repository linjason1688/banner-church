using App.Application.Managements.Users.Dtos;
using MediatR;

namespace App.Application.Features.ChildSignUp
{
    /// <summary>
    /// 登入
    /// </summary>
    public class ChildSignUpCommand : UserBase, IRequest<ChildSignUpCommandResponse>
    {
        
    }
}
