#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.MemberInTags.ModMemberInTags.Queries.FetchAllModMemberInTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMemberInTagRequestValidator 
        : AbstractValidator<FetchAllModMemberInTagRequest>
    {
        public FetchAllModMemberInTagRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
