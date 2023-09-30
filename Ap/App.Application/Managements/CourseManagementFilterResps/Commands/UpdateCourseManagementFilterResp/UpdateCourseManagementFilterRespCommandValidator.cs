#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Commands.UpdateCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCourseManagementFilterRespCommandValidator 
        : AbstractValidator<UpdateCourseManagementFilterRespCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateCourseManagementFilterRespCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterResp, e => e.Name)
            //     );
        }
    }
}
