#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberClasses.Commands.DeleteVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteVwMemberClassCommandValidator 
        : AbstractValidator<DeleteVwMemberClassCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteVwMemberClassCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
