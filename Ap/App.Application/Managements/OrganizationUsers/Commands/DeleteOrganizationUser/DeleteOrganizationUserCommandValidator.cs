#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.OrganizationUsers.Commands.DeleteOrganizationUser
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteOrganizationUserCommandValidator 
        : AbstractValidator<DeleteOrganizationUserCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteOrganizationUserCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
