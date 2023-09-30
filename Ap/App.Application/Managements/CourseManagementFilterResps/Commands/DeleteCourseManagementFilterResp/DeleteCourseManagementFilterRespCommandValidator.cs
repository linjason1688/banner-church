#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.CourseManagementFilterResps.Commands.DeleteCourseManagementFilterResp
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteCourseManagementFilterRespCommandValidator 
        : AbstractValidator<DeleteCourseManagementFilterRespCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteCourseManagementFilterRespCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
