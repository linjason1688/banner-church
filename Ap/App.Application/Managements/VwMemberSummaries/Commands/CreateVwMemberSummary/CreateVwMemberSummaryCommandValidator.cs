#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwMemberSummaries.Commands.CreateVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberSummaryCommandValidator 
        : AbstractValidator<CreateVwMemberSummaryCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberSummaryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberSummary, e => e.Name)
            //     );
        }
    }
}
