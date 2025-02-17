namespace TesteTecFullstackAngular.Api.Core
{
    public class BusinessException : Exception
    {
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }

        public BusinessException(string message, string errorCode = null, int statusCode = StatusCodes.Status400BadRequest)
            : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }
    }
}
