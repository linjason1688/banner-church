#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrgUsers.Commands.UpdateSysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysOrgUserCommandValidator 
        : AbstractValidator<UpdateSysOrgUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysOrgUserCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysOrgUser, e => e.Name)
            //     );
        }
    }
}
