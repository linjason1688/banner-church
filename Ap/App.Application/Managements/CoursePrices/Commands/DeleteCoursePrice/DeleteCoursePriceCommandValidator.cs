#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CoursePrices.Commands.DeleteCoursePrice
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCoursePriceCommandValidator 
        : AbstractValidator<DeleteCoursePriceCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCoursePriceCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
