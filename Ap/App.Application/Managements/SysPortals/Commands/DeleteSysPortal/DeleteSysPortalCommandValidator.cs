#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysPortals.Commands.DeleteSysPortal
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysPortalCommandValidator 
        : AbstractValidator<DeleteSysPortalCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysPortalCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
