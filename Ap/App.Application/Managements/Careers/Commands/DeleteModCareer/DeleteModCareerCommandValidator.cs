#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Careers.ModCareers.Commands.DeleteModCareer
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModCareerCommandValidator 
        : AbstractValidator<DeleteModCareerCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModCareerCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
