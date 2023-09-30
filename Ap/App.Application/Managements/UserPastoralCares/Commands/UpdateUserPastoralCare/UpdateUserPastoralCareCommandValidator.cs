#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserPastoralCares.Commands.UpdateUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserPastoralCareCommandValidator 
        : AbstractValidator<UpdateUserPastoralCareCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserPastoralCareCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserPastoralCare, e => e.Name)
            //     );
        }
    }
}
