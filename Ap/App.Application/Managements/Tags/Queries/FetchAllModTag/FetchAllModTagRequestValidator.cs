#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Tags.ModTags.Queries.FetchAllModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModTagRequestValidator 
        : AbstractValidator<FetchAllModTagRequest>
    {
        public FetchAllModTagRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
