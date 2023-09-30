using System;
using System.Threading.Tasks;
using App.Application.Common.Dtos;

namespace App.Application.Common.Interfaces.Services.Core
{
    public interface IHandleErrorService
    {
        Task<ApiResponse<object>> HandleErrorAsync(Exception ex);
    }
}
