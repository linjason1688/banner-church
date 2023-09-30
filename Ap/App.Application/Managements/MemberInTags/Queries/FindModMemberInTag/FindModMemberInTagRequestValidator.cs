#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Queries.FindModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMemberInTagRequestValidator 
        : AbstractValidator<FindModMemberInTagRequest>
    {
        public FindModMemberInTagRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
