using System.Net;
using irctc.DTOs;
using irctc.Exceptions;

namespace irctc.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var res = context.Response;
                var response = new ResponseDto<string>();

                if (ex.GetType().BaseType == typeof(BaseException))
                {
                    var e = (BaseException)ex;
                    res.StatusCode = e.StatusCode;
                    response.Error = e.ErrorMessage ?? "";
                }
                else
                {
                    res.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Error = "An unexpected error occurred while performing the operation";
                }
                await res.WriteAsJsonAsync(response);
            }
        }
    }
}