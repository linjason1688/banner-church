#region

using System;
using App.Application.Common.Dtos;

#endregion

namespace App.Application.Common.Exceptions
{
    public sealed class MyBusinessException : Exception
    {
        public int HttpStatusCode { get; } = 400;

        public string Code { get; }

        public object ExtraData { get; }

        public MyBusinessException(string msg, string code = null, object data = null, Exception ex = null)
            : base(msg, ex)
        {
            this.Code = code;
            this.ExtraData = data;
            this.Data[nameof(this.ExtraData)] = data;
        }

        public MyBusinessException(ErrorCode code, object data = null, Exception ex = null)
            : this(code.Message, code.Code, data, ex)
        {
            this.HttpStatusCode = code.HttpStatusCode;
        }

        public MyBusinessException(ErrorCode code, string hint, object data = null, Exception ex = null)
            : this(
                string.IsNullOrEmpty(code.Message)
                    ? hint
                    : $"{code.Message} ({hint})",
                code.Code,
                data,
                ex
            )
        {
            this.HttpStatusCode = code.HttpStatusCode;
        }
    }
}
