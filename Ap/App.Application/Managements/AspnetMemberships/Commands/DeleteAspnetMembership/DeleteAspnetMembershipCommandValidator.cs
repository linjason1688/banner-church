#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetMemberships.Commands.DeleteAspnetMembership
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetMembershipCommandValidator 
        : AbstractValidator<DeleteAspnetMembershipCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetMembershipCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
