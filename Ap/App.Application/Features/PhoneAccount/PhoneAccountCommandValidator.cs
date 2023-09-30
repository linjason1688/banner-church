using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace App.Application.Features.PhoneAccount
{
    public sealed class PhoneAccountCommandValidator :  AbstractValidator<PhoneAccountCommand>
    {
        public PhoneAccountCommandValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
