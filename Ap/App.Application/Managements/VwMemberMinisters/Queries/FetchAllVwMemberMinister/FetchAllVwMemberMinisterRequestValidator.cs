#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwMemberMinisters.Queries.FetchAllVwMemberMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllVwMemberMinisterRequestValidator 
        : AbstractValidator<FetchAllVwMemberMinisterRequest>
    {
        public FetchAllVwMemberMinisterRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
