using System;

namespace App.Application.Common.Dtos
{
    /// <summary>
    /// 提供 request 額外的資訊
    /// </summary>
    public class ClientRequestInfo
    {
        /// <summary>
        /// </summary>
        public string ExampleHeaderKeyX { get; set; }


        /// <summary>
        /// IP
        /// </summary>
        /// <returns></returns>
        public string IpAddress { get; set; }

        public DeviceInfo DeviceInfo { get; set; }
    }
}
