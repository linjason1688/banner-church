#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserFamilies.Commands.UpdateUserFamily
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserFamilyCommandValidator 
        : AbstractValidator<UpdateUserFamilyCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserFamilyCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserFamily, e => e.Name)
            //     );
        }
    }
}
