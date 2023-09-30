#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministries.Commands.UpdateMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMinistryCommandValidator 
        : AbstractValidator<UpdateMinistryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMinistryCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Ministry, e => e.Name)
            //     );
        }
    }
}
