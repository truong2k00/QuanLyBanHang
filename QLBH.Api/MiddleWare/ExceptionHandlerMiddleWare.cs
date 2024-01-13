using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace QLBH.Api.MiddleWare
{
    public class ExceptionHandlerMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails details = new()
                {
                    Detail = ex.Message,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Server Error",
                    Type = "Server Error",
                };
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(details));
            }
        }
    }
}
