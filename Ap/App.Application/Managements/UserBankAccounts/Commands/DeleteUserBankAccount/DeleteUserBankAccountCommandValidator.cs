#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserBankAccounts.Commands.DeleteUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteUserBankAccountCommandValidator 
        : AbstractValidator<DeleteUserBankAccountCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public DeleteUserBankAccountCommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
