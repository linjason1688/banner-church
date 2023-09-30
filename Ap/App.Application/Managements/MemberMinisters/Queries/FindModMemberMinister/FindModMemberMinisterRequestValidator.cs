#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberMinisters.ModMemberMinisters.Queries.FindModMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberMinisterRequestValidator 
        : AbstractValidator<FindModMemberMinisterRequest>
    {
        public FindModMemberMinisterRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
