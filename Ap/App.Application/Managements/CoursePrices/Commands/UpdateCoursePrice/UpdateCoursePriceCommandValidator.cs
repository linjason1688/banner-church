#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CoursePrices.Commands.UpdateCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCoursePriceCommandValidator 
        : AbstractValidator<UpdateCoursePriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCoursePriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CoursePrice, e => e.Name)
            //     );
        }
    }
}
