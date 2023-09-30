#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.Pastorals.Commands.UpdatePastoral
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatePastoralCommandValidator 
        : AbstractValidator<UpdatePastoralCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdatePastoralCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.Pastoral, e => e.Name)
            //     );
        }
    }
}
