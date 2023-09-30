#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberSummaries.Commands.UpdateVwMemberSummary
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwMemberSummaryCommandValidator 
        : AbstractValidator<UpdateVwMemberSummaryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwMemberSummaryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberSummary, e => e.Name)
            //     );
        }
    }
}
