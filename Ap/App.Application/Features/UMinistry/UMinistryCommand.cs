using System.Collections.Generic;
using App.Application.Common.Attributes;
using App.Application.Managements.Ministries.Dtos;
using App.Application.Managements.MinistryResps.Commands.CreateMinistryResp;
using MediatR;

namespace App.Application.Features.UMinistry
{
    //#CreateAPI
    /// <summary>
    /// 建立部門
    /// </summary>
    [SwaggerCustomId(Id = "AddMinistryCommand")]
    public class UMinistryCommand : MinistryBase, IRequest<UMinistryCommandResponse>
    {
        /// <summary>
        /// 事工團職分明細
        /// </summary>
        public List<CreateMinistryRespCommand> MinistryResps { get; set; }

    }

    public class UMinistryUpdateCommand : MinistryBase, IRequest<UMinistryCommandResponse>
    {
        /// <summary>
        /// 事工團職分明細
        /// </summary>
        public List<CreateMinistryRespCommand> MinistryResps { get; set; }
    }

}
