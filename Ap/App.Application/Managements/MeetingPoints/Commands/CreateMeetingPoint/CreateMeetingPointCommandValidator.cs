#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.MeetingPoints.Commands.CreateMeetingPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateMeetingPointCommandValidator 
        : AbstractValidator<CreateMeetingPointCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateMeetingPointCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.MeetingPoint, e => e.Name)
            //     );
        }
    }
}
