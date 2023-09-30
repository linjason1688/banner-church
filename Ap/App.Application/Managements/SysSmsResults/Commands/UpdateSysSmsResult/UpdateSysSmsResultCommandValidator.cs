#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSmsResults.Commands.UpdateSysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSysSmsResultCommandValidator 
        : AbstractValidator<UpdateSysSmsResultCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateSysSmsResultCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSmsResult, e => e.Name)
            //     );
        }
    }
}
