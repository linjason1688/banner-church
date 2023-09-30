#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberTags.Commands.DeleteVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMemberTagCommandValidator 
        : AbstractValidator<DeleteVwMemberTagCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMemberTagCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
