#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Logs.ModLogs.Commands.DeleteModLog
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteModLogCommandValidator 
        : AbstractValidator<DeleteModLogCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteModLogCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
