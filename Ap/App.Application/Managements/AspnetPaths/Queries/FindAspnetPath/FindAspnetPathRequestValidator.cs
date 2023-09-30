#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.AspnetPaths.Queries.FindAspnetPath
{
    /// <summary>
    /// 
    /// </summary>
    public class FindAspnetPathRequestValidator 
        : AbstractValidator<FindAspnetPathRequest>
    {
        public FindAspnetPathRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
