#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Commands.UpdateAspnetWebeventEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetWebeventEventCommandValidator 
        : AbstractValidator<UpdateAspnetWebeventEventCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetWebeventEventCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetWebeventEvent, e => e.Name)
            //     );
        }
    }
}
