#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.UpdateModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModStatisticDetailCommandValidator 
        : AbstractValidator<UpdateModStatisticDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModStatisticDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModStatisticDetail, e => e.Name)
            //     );
        }
    }
}
