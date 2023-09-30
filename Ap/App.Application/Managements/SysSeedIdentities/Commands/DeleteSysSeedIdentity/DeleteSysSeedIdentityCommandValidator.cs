#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSeedIdentities.Commands.DeleteSysSeedIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysSeedIdentityCommandValidator 
        : AbstractValidator<DeleteSysSeedIdentityCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysSeedIdentityCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
