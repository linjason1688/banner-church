#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;


#endregion

namespace App.Application.Managements.VwOrderRecords.Commands.CreateVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateVwOrderRecordCommandValidator 
        : AbstractValidator<CreateVwOrderRecordCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateVwOrderRecordCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwOrderRecord, e => e.Name)
            //     );
        }
    }
}
