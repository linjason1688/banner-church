#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetUsersinroles.Commands.CreateAspnetUsersinrole
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetUsersinroleCommandValidator 
        : AbstractValidator<CreateAspnetUsersinroleCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetUsersinroleCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetUsersinrole, e => e.Name)
            //     );
        }
    }
}
