#region

using System;

#endregion

namespace App.Application.Common.Exceptions
{
    public sealed class ExternalServiceException : Exception
    {
        public string Code { get; }

        public object ExtraData { get; }

        public ExternalServiceException(string msg, string code = null, object data = null, Exception ex = null)
            : base(msg, ex)
        {
            this.Code = code;
            this.ExtraData = data;
            this.Data[nameof(this.ExtraData)] = data;
        }
    }
}
