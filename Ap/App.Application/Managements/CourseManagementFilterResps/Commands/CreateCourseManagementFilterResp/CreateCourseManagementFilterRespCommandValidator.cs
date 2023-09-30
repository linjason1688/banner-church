#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Commands.CreateCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCourseManagementFilterRespCommandValidator 
        : AbstractValidator<CreateCourseManagementFilterRespCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCourseManagementFilterRespCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.CourseManagementFilterResp, e => e.Name)
            //     );
        }
    }
}
