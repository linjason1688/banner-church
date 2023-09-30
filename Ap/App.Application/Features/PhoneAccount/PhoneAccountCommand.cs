using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace App.Application.Features.PhoneAccount
{
    public sealed class PhoneAccountCommand : IRequest<PhoneAccountResponse>
    {
      

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
    }
}
