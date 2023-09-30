#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetUsersinroles.Commands.UpdateAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetUsersinroleCommandValidator 
        : AbstractValidator<UpdateAspnetUsersinroleCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetUsersinroleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetUsersinrole, e => e.Name)
            //     );
        }
    }
}
