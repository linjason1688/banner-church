#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryResps.Commands.UpdateMinistryResp
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryRespCommandValidator 
        : AbstractValidator<UpdateMinistryRespCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryRespCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryResp, e => e.Name)
            //     );
        }
    }
}
