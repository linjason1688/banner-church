using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace App.Application.Features.EmailPassword
{
    public sealed class EmailPasswordCommandValidator :  AbstractValidator<EmailPasswordCommand>
    {
        public EmailPasswordCommandValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
