using App.Application.Common.Dtos;

namespace App.Application.Common.Interfaces.Services
{
    public interface IClientInfoService
    {
        ClientRequestInfo ClientInfo { get; }

        DeviceInfo DeviceInfo { get; }

        // for test purpose
#if DEBUG
        void SetClientInfo(ClientRequestInfo info);

#endif
    }
}
