#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetMembershipUsers.Commands.DeleteVwAspnetMembershipuser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetMembershipuserCommandValidator 
        : AbstractValidator<DeleteVwAspnetMembershipuserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetMembershipuserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
