#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Commands.UpdateModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModCareerCommandValidator 
        : AbstractValidator<UpdateModCareerCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModCareerCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCareer, e => e.Name)
            //     );
        }
    }
}
