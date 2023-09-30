#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Commands.DeleteVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMemberSummaryCommandValidator 
        : AbstractValidator<DeleteVwMemberSummaryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMemberSummaryCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
