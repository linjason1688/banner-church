#region

using System;
using FluentValidation;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Queries.FetchAll$Target$
{
    /// <summary>
    /// 
    /// </summary>
    public class FetchAll$Target$RequestValidator 
        : AbstractValidator<FetchAll$Target$Request>
    {
        public FetchAll$Target$RequestValidator()
        {
            RuleFor(r => r)
               .NotEmpty();
        }
    }
}
