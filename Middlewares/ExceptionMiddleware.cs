using CaseTracker.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CaseTracker.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger
            , IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task Invoke(HttpContext context) {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                ApiErrors response;
                HttpStatusCode statusCode= HttpStatusCode.InternalServerError;

                String message;

                var exceptionType = ex.GetType();

                if(env.IsDevelopment())
                {
                    response = new ApiErrors((int)statusCode,ex.Message,ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiErrors((int)statusCode, ex.Message);
                }

                logger.LogError(ex,ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType= "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
