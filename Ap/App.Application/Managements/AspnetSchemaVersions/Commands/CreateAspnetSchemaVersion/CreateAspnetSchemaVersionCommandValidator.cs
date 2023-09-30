#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Commands.CreateAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateAspnetSchemaVersionCommandValidator 
        : AbstractValidator<CreateAspnetSchemaVersionCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateAspnetSchemaVersionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetSchemaVersion, e => e.Name)
            //     );
        }
    }
}
