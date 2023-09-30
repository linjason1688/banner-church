using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace App.Application.Features.EmailAccount
{
    public sealed class EmailAccountCommand : IRequest<EmailAccountResponse>
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
