#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Tags.ModTags.Queries.FindModTag
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModTagRequestValidator 
        : AbstractValidator<FindModTagRequest>
    {
        public FindModTagRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
