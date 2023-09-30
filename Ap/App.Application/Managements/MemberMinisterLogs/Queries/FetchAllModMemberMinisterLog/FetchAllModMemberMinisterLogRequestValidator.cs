#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisterLogs.ModMemberMinisterLogs.Queries.FetchAllModMemberMinisterLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberMinisterLogRequestValidator 
        : AbstractValidator<FetchAllModMemberMinisterLogRequest>
    {
        public FetchAllModMemberMinisterLogRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
