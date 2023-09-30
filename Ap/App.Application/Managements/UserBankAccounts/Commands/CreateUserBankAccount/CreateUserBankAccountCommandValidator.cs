#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.UserBankAccounts.Commands.CreateUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateUserBankAccountCommandValidator 
        : AbstractValidator<CreateUserBankAccountCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateUserBankAccountCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.UserBankAccount, e => e.Name)
            //     );
        }
    }
}
