using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace App.Application.Features.EmailPassword
{
    public sealed class EmailPasswordCommand : IRequest<EmailPasswordResponse>
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
