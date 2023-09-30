#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.ClassDays.ModClassDays.Queries.QueryModClassDay
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModClassDayRequestValidator 
        : AbstractValidator<QueryModClassDayRequest>
    {
        public QueryModClassDayRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
