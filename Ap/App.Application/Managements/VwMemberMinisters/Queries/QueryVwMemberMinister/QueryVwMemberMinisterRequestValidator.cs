#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Queries.QueryVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryVwMemberMinisterRequestValidator 
        : AbstractValidator<QueryVwMemberMinisterRequest>
    {
        public QueryVwMemberMinisterRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
