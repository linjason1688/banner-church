#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberClasses.Queries.FetchAllVwMemberClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMemberClassRequestValidator 
        : AbstractValidator<FetchAllVwMemberClassRequest>
    {
        public FetchAllVwMemberClassRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
