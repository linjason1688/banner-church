#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Commands.CreateModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModStatisticCommandValidator 
        : AbstractValidator<CreateModStatisticCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModStatisticCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModStatistic, e => e.Name)
            //     );
        }
    }
}
