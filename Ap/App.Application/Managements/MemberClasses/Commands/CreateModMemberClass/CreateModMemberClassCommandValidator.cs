#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MemberClasses.ModMemberClasses.Commands.CreateModMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModMemberClassCommandValidator 
        : AbstractValidator<CreateModMemberClassCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModMemberClassCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModMemberClass, e => e.Name)
            //     );
        }
    }
}
