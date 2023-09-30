#region

using System;
using FluentValidation;

#endregion

namespace App.Application.Managements.Departments.ModDepartments.Queries.QueryModDepartment
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryModDepartmentRequestValidator 
        : AbstractValidator<QueryModDepartmentRequest>
    {
        public QueryModDepartmentRequestValidator()
        {
            RuleFor(r => r);
        }
    }
}
