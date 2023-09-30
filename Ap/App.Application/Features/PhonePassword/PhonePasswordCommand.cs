using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace App.Application.Features.PhonePassword
{
    public sealed class PhonePasswordCommand : IRequest<PhonePasswordResponse>
    {
        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }
    }
}
