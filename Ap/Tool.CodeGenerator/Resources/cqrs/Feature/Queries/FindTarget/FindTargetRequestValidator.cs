#region

using System;
using FluentValidation;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Queries.Find$Target$
{
    /// <summary>
    /// 
    /// </summary>
    public class Find$Target$RequestValidator 
        : AbstractValidator<Find$Target$Request>
    {
        public Find$Target$RequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
