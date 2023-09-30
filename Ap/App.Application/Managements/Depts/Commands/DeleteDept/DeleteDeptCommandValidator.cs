#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Depts.Commands.DeleteDept
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteDeptCommandValidator 
        : AbstractValidator<DeleteDeptCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteDeptCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
