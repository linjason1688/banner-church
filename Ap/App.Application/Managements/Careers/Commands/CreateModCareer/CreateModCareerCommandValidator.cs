#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Careers.ModCareers.Commands.CreateModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateModCareerCommandValidator 
        : AbstractValidator<CreateModCareerCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateModCareerCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCareer, e => e.Name)
            //     );
        }
    }
}
