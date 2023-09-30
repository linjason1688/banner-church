#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwWorkSignups.Commands.DeleteVwWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwWorkSignupCommandValidator 
        : AbstractValidator<DeleteVwWorkSignupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwWorkSignupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
