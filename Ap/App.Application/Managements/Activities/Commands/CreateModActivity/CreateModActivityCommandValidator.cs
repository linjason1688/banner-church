#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Activities.ModActivities.Commands.CreateModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModActivityCommandValidator 
        : AbstractValidator<CreateModActivityCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModActivityCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivity, e => e.Name)
            //     );
        }
    }
}
