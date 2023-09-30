#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysOrgUsers.Commands.CreateSysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysOrgUserCommandValidator 
        : AbstractValidator<CreateSysOrgUserCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysOrgUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysOrgUser, e => e.Name)
            //     );
        }
    }
}
