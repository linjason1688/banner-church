#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.CreateModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModStatisticDetailCommandValidator 
        : AbstractValidator<CreateModStatisticDetailCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModStatisticDetailCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModStatisticDetail, e => e.Name)
            //     );
        }
    }
}
