#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.SystemConfigs.Commands.DeleteSystemConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteSystemConfigCommandValidator 
        : AbstractValidator<DeleteSystemConfigCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteSystemConfigCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
