using System.Net;

namespace irctc.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public BaseException(int statusCode, string? errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}