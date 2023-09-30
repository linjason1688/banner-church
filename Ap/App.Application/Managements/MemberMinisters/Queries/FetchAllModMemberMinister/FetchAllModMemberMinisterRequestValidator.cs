#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Queries.FetchAllModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberMinisterRequestValidator 
        : AbstractValidator<FetchAllModMemberMinisterRequest>
    {
        public FetchAllModMemberMinisterRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
