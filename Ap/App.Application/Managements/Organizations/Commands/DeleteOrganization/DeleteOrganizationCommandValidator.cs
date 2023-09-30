#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Organizations.Commands.DeleteOrganization
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteOrganizationCommandValidator 
        : AbstractValidator<DeleteOrganizationCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteOrganizationCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
