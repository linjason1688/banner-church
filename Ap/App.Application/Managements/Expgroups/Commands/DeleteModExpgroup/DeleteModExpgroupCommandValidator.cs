#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Expgroups.ModExpgroups.Commands.DeleteModExpgroup
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModExpgroupCommandValidator 
        : AbstractValidator<DeleteModExpgroupCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModExpgroupCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
