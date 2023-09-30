#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Tags.ModTags.Commands.DeleteModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModTagCommandValidator 
        : AbstractValidator<DeleteModTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModTagCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
