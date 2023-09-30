#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ActivityWorkSignups.ModActivityWorkSignups.Commands.DeleteModActivityWorkSignup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModActivityWorkSignupCommandValidator 
        : AbstractValidator<DeleteModActivityWorkSignupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModActivityWorkSignupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
