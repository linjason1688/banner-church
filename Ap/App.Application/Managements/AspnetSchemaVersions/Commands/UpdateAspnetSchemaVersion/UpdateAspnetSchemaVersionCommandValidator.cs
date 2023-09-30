#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetSchemaVersions.Commands.UpdateAspnetSchemaVersion
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAspnetSchemaVersionCommandValidator 
        : AbstractValidator<UpdateAspnetSchemaVersionCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateAspnetSchemaVersionCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.AspnetSchemaVersion, e => e.Name)
            //     );
        }
    }
}
