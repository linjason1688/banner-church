#region

using System;
using App.Application.Common.Interfaces;
using FluentValidation;

#endregion

namespace App.Application.Managements.CampaignSpdays.ModCampaignSpdays.Commands.UpdateModCampaignSpday
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateModCampaignSpdayCommandValidator 
        : AbstractValidator<UpdateModCampaignSpdayCommand>
    {
    
        /// <summary>
        /// 
        /// </summary>
        public UpdateModCampaignSpdayCommandValidator(IAppDbContext appDbContext)
        {
            this.RuleFor(r => r.Id)
               .GreaterThan(0);
            
            // this.RuleFor(r => r.Name)
            //    .NotEmpty()
            //    .MaximumLength(
            //         appDbContext.GetMaxLength(d => d.ModCampaignSpday, e => e.Name)
            //     );
        }
    }
}
