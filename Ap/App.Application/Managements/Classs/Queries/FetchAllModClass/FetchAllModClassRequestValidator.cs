#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Classs.ModClasss.Queries.FetchAllModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAllModClassRequestValidator 
        : AbstractValidator<FetchAllModClassRequest>
    {
        public FetchAllModClassRequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
