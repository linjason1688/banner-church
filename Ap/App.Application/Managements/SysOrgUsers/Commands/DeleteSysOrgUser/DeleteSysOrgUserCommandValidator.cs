#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysOrgUsers.Commands.DeleteSysOrgUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysOrgUserCommandValidator 
        : AbstractValidator<DeleteSysOrgUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysOrgUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
