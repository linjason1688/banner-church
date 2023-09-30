#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Statistics.ModStatistics.Commands.DeleteModStatistic
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModStatisticCommandValidator 
        : AbstractValidator<DeleteModStatisticCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModStatisticCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
