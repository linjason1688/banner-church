using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace App.Application.Features.PhonePassword
{
    public sealed class PhonePasswordCommandValidator :  AbstractValidator<PhonePasswordCommand>
    {
        public PhonePasswordCommandValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
