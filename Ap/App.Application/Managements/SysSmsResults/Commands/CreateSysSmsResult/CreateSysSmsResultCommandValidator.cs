#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.SysSmsResults.Commands.CreateSysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateSysSmsResultCommandValidator 
        : AbstractValidator<CreateSysSmsResultCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateSysSmsResultCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.SysSmsResult, e => e.Name)
            //     );
        }
    }
}
