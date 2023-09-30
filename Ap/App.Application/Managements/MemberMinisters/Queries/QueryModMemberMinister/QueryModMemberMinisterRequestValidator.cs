#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Queries.QueryModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModMemberMinisterRequestValidator 
        : AbstractValidator<QueryModMemberMinisterRequest>
    {
        public QueryModMemberMinisterRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
