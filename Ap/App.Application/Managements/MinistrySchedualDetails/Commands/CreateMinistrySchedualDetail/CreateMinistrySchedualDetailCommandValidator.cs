#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryScheduleDetails.Commands.CreateMinistryScheduleDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryScheduleDetailCommandValidator 
        : AbstractValidator<CreateMinistryScheduleDetailCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryScheduleDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryScheduleDetail, e => e.Name)
            //     );
        }
    }
}
