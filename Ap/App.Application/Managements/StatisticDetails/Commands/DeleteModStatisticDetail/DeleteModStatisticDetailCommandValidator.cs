#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.StatisticDetails.ModStatisticDetails.Commands.DeleteModStatisticDetail
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModStatisticDetailCommandValidator 
        : AbstractValidator<DeleteModStatisticDetailCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModStatisticDetailCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
