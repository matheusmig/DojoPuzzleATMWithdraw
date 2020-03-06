namespace WebApi.Middlewares
{
    using Domain.Base.Exceptions;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using WebApi.ViewModels;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException domainEx)
            {
                var code = HttpStatusCode.InternalServerError;
                var resultObj = JsonConvert.SerializeObject(new StandardErrorViewModel()
                {
                    Code = 0,
                    Data = null,
                    Message = domainEx.Message
                });

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;

                await context.Response.WriteAsync(resultObj);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
