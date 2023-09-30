#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CoursePrices.Commands.CreateCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCoursePriceCommandValidator 
        : AbstractValidator<CreateCoursePriceCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCoursePriceCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CoursePrice, e => e.Name)
            //     );
        }
    }
}
