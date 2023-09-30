#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.FindUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class FindUserBankAccountRequestValidator 
        : AbstractValidator<FindUserBankAccountRequest>
    {
        public FindUserBankAccountRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
