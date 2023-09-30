#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwCheckInMemberClasses.Commands.DeleteVwCheckInMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwCheckInMemberClassCommandValidator 
        : AbstractValidator<DeleteVwCheckInMemberClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwCheckInMemberClassCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
