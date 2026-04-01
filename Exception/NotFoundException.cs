using System.Net;
using irctc.Exceptions;

namespace todo.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string? errorMessage = null) : base((int)HttpStatusCode.NotFound, errorMessage)
        {
        }
    }
}