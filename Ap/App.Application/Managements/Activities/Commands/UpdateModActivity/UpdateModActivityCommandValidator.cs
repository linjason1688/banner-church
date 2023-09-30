#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Activities.ModActivities.Commands.UpdateModActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModActivityCommandValidator 
        : AbstractValidator<UpdateModActivityCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModActivityCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModActivity, e => e.Name)
            //     );
        }
    }
}
