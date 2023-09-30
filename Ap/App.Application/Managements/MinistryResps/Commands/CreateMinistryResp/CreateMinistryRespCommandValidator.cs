#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryResps.Commands.CreateMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryRespCommandValidator 
        : AbstractValidator<CreateMinistryRespCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryRespCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryResp, e => e.Name)
            //     );
        }
    }
}
