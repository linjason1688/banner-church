#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryDefs.Commands.UpdateMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryDefCommandValidator 
        : AbstractValidator<UpdateMinistryDefCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryDefCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryDef, e => e.Name)
            //     );
        }
    }
}
