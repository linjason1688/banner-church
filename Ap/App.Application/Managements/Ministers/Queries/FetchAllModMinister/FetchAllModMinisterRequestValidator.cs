#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Queries.FetchAllModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModMinisterRequestValidator 
        : AbstractValidator<FetchAllModMinisterRequest>
    {
        public FetchAllModMinisterRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
