#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserPastoralCares.Commands.CreateUserPastoralCare
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserPastoralCareCommandValidator 
        : AbstractValidator<CreateUserPastoralCareCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserPastoralCareCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserPastoralCare, e => e.Name)
            //     );
        }
    }
}
