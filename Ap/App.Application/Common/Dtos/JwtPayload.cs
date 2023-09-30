#region

using System;
using Newtonsoft.Json;

#endregion

namespace App.Application.Common.Dtos
{
    public abstract class JwtPayload
    {
        [JsonProperty("exp")]
        public long ExpiredAt;

        [JsonIgnore]
        public DateTime ExpiredDateTimeAt => DateTime.UnixEpoch.Date.AddSeconds(this.ExpiredAt);

        public JwtPayload SetExpiredAt(DateTime dateTime)
        {
            this.ExpiredAt = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

            return this;
        }
    }
}
