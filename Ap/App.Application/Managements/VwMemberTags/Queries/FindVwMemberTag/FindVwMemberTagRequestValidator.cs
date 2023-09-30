#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberTags.Queries.FindVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberTagRequestValidator 
        : AbstractValidator<FindVwMemberTagRequest>
    {
        public FindVwMemberTagRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
