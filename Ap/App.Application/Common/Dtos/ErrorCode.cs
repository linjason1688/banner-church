namespace App.Application.Common.Dtos
{
    public class ErrorCode
    {
        public string Code { get; }

        public int HttpStatusCode { get; }

        public string Message { get; }

        public ErrorCode(string code, string message, int httpStatusCode = 400)
        {
            this.Code = code;
            this.Message = message;
            this.HttpStatusCode = httpStatusCode;
        }
    }
}
