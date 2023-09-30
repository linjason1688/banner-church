#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserBankAccounts.Commands.UpdateUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateUserBankAccountCommandValidator 
        : AbstractValidator<UpdateUserBankAccountCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateUserBankAccountCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserBankAccount, e => e.Name)
            //     );
        }
    }
}
