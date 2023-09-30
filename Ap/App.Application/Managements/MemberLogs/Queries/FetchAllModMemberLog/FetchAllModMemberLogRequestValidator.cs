#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberLogs.ModMemberLogs.Queries.FetchAllModMemberLog
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberLogRequestValidator 
        : AbstractValidator<FetchAllModMemberLogRequest>
    {
        public FetchAllModMemberLogRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
