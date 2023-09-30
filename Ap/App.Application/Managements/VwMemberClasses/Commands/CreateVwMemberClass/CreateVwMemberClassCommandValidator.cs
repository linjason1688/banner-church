#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwMemberClasses.Commands.CreateVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwMemberClassCommandValidator 
        : AbstractValidator<CreateVwMemberClassCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwMemberClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwMemberClass, e => e.Name)
            //     );
        }
    }
}
