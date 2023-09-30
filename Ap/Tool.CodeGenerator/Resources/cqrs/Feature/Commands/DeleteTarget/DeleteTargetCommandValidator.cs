#region

using System;
using FluentValidation;

#endregion

namespace App.Application.$BaseNamespace$$Feature$.Commands.Delete$Target$
{
    /// <summary>
    /// 
    /// </summary>
    public class Delete$Target$CommandValidator 
        : AbstractValidator<Delete$Target$Command>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public Delete$Target$CommandValidator()
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
        }
    }
}
