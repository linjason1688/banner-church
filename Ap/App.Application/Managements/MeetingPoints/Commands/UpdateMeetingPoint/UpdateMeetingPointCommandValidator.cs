#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.MeetingPoints.Commands.UpdateMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateMeetingPointCommandValidator 
        : AbstractValidator<UpdateMeetingPointCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateMeetingPointCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MeetingPoint, e => e.Name)
            //     );
        }
    }
}
