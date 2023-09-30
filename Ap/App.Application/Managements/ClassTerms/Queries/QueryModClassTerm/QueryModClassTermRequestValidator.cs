#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassTerms.ModClassTerms.Queries.QueryModClassTerm
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModClassTermRequestValidator 
        : AbstractValidator<QueryModClassTermRequest>
    {
        public QueryModClassTermRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
