using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Managements.Ministries.Queries.FindMinistry;
using FluentValidation;

namespace App.Application.Features.FindMinistryRecord
{
    public class FindMinistryRecordRequestValidator : AbstractValidator<FindMinistryRecordRequest>
    {
        public FindMinistryRecordRequestValidator()
        {
            //暂不Valid
            // RuleFor(m => m.Email)
            //    .NotEmpty()
            //    .When(m => string.IsNullOrEmpty(m.MobileNo));
            //
            // RuleFor(m => m.MobileNo)
            //    .NotEmpty()
            //    .When(m => string.IsNullOrEmpty(m.Email));
        }
    }
}
