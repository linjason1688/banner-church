using System.Net;
using System.Net.Mime;
using App.Application.Common.Dtos;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Api.Apis
{
    /// <summary>
    /// </summary>
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<object>), (int) HttpStatusCode.InternalServerError)]
    public abstract class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// </summary>
        protected IMediator Mediator => this.HttpContext.RequestServices.GetService<IMediator>();
    }
}
