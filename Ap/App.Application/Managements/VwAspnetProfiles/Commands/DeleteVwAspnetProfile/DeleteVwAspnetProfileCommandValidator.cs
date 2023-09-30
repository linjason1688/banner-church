#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwAspnetProfiles.Commands.DeleteVwAspnetProfile
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwAspnetProfileCommandValidator 
        : AbstractValidator<DeleteVwAspnetProfileCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwAspnetProfileCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
