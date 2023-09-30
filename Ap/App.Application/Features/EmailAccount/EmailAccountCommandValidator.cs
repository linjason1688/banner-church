using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace App.Application.Features.EmailAccount
{
    public sealed class EmailAccountCommandValidator :  AbstractValidator<EmailAccountCommand>
    {
        public EmailAccountCommandValidator()
        {
            this.RuleFor(r => r);
        }
    }
}
