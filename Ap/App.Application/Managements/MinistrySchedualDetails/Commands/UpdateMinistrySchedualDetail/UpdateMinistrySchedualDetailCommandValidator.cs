#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Commands.UpdateMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryScheduleDetailCommandValidator 
        : AbstractValidator<UpdateMinistryScheduleDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryScheduleDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryScheduleDetail, e => e.Name)
            //     );
        }
    }
}
