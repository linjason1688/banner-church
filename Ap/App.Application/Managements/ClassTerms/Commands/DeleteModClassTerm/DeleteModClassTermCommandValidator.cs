#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Commands.DeleteModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModClassTermCommandValidator 
        : AbstractValidator<DeleteModClassTermCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModClassTermCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
