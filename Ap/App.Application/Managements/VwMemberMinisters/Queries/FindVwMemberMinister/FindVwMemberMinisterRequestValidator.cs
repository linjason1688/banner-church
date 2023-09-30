#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Queries.FindVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FindVwMemberMinisterRequestValidator 
        : AbstractValidator<FindVwMemberMinisterRequest>
    {
        public FindVwMemberMinisterRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
