using System.Net;
using irctc.Exceptions;

namespace todo.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string? errorMessage = null) : base((int)HttpStatusCode.BadRequest, errorMessage)
        {
        }
    }
}