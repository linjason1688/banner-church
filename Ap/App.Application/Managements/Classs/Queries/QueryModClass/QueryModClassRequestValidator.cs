#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Classs.ModClasss.Queries.QueryModClass
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModClassRequestValidator 
        : AbstractValidator<QueryModClassRequest>
    {
        public QueryModClassRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
