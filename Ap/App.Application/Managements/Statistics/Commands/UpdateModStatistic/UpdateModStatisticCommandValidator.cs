#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Commands.UpdateModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModStatisticCommandValidator 
        : AbstractValidator<UpdateModStatisticCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModStatisticCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModStatistic, e => e.Name)
            //     );
        }
    }
}
