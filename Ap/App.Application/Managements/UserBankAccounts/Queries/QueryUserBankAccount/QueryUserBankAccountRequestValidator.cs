#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.UserBankAccounts.Queries.QueryUserBankAccount
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryUserBankAccountRequestValidator 
        : AbstractValidator<QueryUserBankAccountRequest>
    {
        public QueryUserBankAccountRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
