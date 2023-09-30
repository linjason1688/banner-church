using System.Collections.Generic;
using App.Application.Common.Attributes;
using App.Application.Features.CreateMinistryDef;
using App.Application.Managements.Pastorals.Dtos;
using App.Application.Managements.UserBankAccounts.Commands.CreateUserBankAccount;
using App.Application.Managements.UserBankAccounts.Commands.UpdateUserBankAccount;
using App.Application.Managements.UserContacts.Commands.CreateUserContact;
using App.Application.Managements.UserContacts.Commands.UpdateUserContact;
using App.Application.Managements.UserExpertises.Commands.CreateUserExpertise;
using App.Application.Managements.UserExpertises.Commands.UpdateUserExpertise;
using App.Application.Managements.UserFamilies.Commands.CreateUserFamily;
using App.Application.Managements.UserFamilies.Commands.UpdateUserFamily;
using App.Application.Managements.Users.Dtos;
using MediatR;

namespace App.Application.Features.UPastoral
{
    //#CreateAPI
    /// <summary>
    /// 建立部門
    /// </summary>
    [SwaggerCustomId(Id = "AddPastoralCommand")]
    public class UPastoralCommand : PastoralBase, IRequest<UPastoralResponse>
    {
       
    }
}
