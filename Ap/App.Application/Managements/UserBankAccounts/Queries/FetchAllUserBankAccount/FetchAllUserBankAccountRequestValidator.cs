#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.FetchAllUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllUserBankAccountRequestValidator 
        : AbstractValidator<FetchAllUserBankAccountRequest>
    {
        public FetchAllUserBankAccountRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
