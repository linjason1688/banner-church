#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetWebeventEvents.Commands.DeleteAspnetWebeventEvent
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetWebeventEventCommandValidator 
        : AbstractValidator<DeleteAspnetWebeventEventCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetWebeventEventCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
