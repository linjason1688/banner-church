#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.Pastorals.Commands.CreatePastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePastoralCommandValidator 
        : AbstractValidator<CreatePastoralCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreatePastoralCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Pastoral, e => e.Name)
            //     );
        }
    }
}
