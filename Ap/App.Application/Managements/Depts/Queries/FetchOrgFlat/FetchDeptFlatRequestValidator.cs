using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Managements.Depts.Queries.FindDept;
using FluentValidation;

namespace App.Application.Managements.Depts.Queries.FetchDeptFlat
{
    public class FetchDeptFlatRequestValidator
       : AbstractValidator<FetchDeptFlatRequest>
    {
        public FetchDeptFlatRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
