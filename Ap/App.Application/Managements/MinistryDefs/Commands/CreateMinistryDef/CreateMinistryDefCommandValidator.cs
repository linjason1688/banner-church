#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MinistryDefs.Commands.CreateMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMinistryDefCommandValidator 
        : AbstractValidator<CreateMinistryDefCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMinistryDefCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MinistryDef, e => e.Name)
            //     );
        }
    }
}
