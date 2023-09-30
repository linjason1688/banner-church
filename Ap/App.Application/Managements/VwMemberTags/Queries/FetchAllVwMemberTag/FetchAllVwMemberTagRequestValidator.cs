#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberTags.Queries.FetchAllVwMemberTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMemberTagRequestValidator 
        : AbstractValidator<FetchAllVwMemberTagRequest>
    {
        public FetchAllVwMemberTagRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
