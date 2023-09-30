#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Classs.ModClasss.Queries.FindModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class FindModClassRequestValidator 
        : AbstractValidator<FindModClassRequest>
    {
        public FindModClassRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
