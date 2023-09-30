#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.VwOrderRecords.Commands.UpdateVwOrderRecord
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateVwOrderRecordCommandValidator 
        : AbstractValidator<UpdateVwOrderRecordCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateVwOrderRecordCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.VwOrderRecord, e => e.Name)
            //     );
        }
    }
}
