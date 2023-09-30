#pragma warning disable CS1591

#region

using System;

#endregion

namespace App.Application.Common.Dtos
{
    public class ApiActionInfo
    {
        public Guid HandledId { get; set; }

        public Guid AuthApiKey { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public string SourceIp { get; set; }

        public string HttpMethod { get; set; }

        public string RequestQueryString { get; set; }

        public string RequestHeaders { get; set; }

        public int ResponseStatusCode { get; set; }

        public string RequestPath { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public long TimeElapsed { get; set; }
    }
}
