using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GSRS.Infrastructure.Models;
using Microsoft.AspNetCore.Http;

namespace GSRS.Infrastructure.ErrorHandlingMiddleWare
{
    public class ExceptionHandlingMiddleware
    {
       private readonly RequestDelegate _next;

       
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            // This is nothing but switch case and assign response.StatusCode value
            response.StatusCode = exception switch
            {
                ValidationException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError,// default unhandled error
            };

            return response.WriteAsync(JsonSerializer.Serialize(new ErrorResponseViewModel(exception)));
        }
    }
}