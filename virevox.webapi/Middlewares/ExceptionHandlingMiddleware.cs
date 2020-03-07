using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Virevox.application.core;

namespace Virevox.WebApi
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
               await _next(context);
            }
            catch(Exception exception)
            {
                var statusCode = HttpStatusCode.InternalServerError;

                if (exception is BadRequestException)
                    statusCode = HttpStatusCode.BadRequest;

                context.Response.StatusCode = (int)statusCode;
                var jsonResponse = new { Message = exception.Message };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(jsonResponse));
            }
        }
    }
}