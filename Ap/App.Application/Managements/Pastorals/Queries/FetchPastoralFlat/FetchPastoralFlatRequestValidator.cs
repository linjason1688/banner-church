using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Managements.Pastorals.Queries.FindPastoral;
using FluentValidation;

namespace App.Application.Managements.Pastorals.Queries.FetchPastoralFlat
{
    public class FetchPastoralFlatRequestValidator
       : AbstractValidator<FetchPastoralFlatRequest>
    {
        public FetchPastoralFlatRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
