#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Ministers.ModMinisters.Queries.FindModMinister
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModMinisterRequestValidator 
        : AbstractValidator<FindModMinisterRequest>
    {
        public FindModMinisterRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
