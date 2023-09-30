using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Managements.Organizations.Queries.FindOrganization;
using FluentValidation;

namespace App.Application.Managements.Organizations.Queries.FetchOrganizationFlat
{
    public class FetchOrgFlatRequestValidator
       : AbstractValidator<FetchOrgFlatRequest>
    {
        public FetchOrgFlatRequestValidator()
        {
            RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
