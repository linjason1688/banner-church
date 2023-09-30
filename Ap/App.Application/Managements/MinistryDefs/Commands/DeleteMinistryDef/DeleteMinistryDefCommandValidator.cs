#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MinistryDefs.Commands.DeleteMinistryDef
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryDefCommandValidator 
        : AbstractValidator<DeleteMinistryDefCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryDefCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
