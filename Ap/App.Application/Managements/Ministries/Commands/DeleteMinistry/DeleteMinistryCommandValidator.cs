#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministries.Commands.DeleteMinistry
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteMinistryCommandValidator 
        : AbstractValidator<DeleteMinistryCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteMinistryCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
