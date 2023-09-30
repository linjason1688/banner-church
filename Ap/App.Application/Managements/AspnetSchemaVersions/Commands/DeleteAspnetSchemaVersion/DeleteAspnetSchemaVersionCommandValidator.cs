#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Commands.DeleteAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAspnetSchemaVersionCommandValidator 
        : AbstractValidator<DeleteAspnetSchemaVersionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteAspnetSchemaVersionCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
