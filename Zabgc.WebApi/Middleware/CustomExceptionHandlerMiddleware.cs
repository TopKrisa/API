using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Zabgc.Application.Common.Exceptions;

namespace Zabgc.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            (HttpStatusCode Code, string Status) exceptionResult = ExceptionHandler(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exceptionResult.Code;
            if (exceptionResult.Status == string.Empty)
            {
                exceptionResult.Status = JsonSerializer.Serialize(new { error = exception.Message });
            }
            return context.Response.WriteAsync(exceptionResult.Status);
        }
        private (HttpStatusCode code, string status) ExceptionHandler(Exception exception)
        {
            switch (exception)
            {
                case ValidationException validationException:
                    return (HttpStatusCode.BadRequest, JsonSerializer.Serialize(validationException.Errors));
                case NotFoundException notFoundException:
                    return (HttpStatusCode.NotFound, string.Empty);
                default:
                    return (HttpStatusCode.InternalServerError, string.Empty);
            }
        }
    }
}
