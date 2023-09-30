#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SysSmsResults.Commands.DeleteSysSmsResult
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSysSmsResultCommandValidator 
        : AbstractValidator<DeleteSysSmsResultCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSysSmsResultCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
