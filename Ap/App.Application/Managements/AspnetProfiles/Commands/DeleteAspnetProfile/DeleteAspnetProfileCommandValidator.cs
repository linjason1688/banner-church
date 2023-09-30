#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetProfiles.Commands.DeleteAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetProfileCommandValidator 
        : AbstractValidator<DeleteAspnetProfileCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetProfileCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
