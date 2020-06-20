using DemoCoreAPI.BusinessLogic.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCoreAPI.Web.Middleware
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _jsonSettings;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));

            _jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case ArgumentNullException _:
                    case ArgumentException _:
                    case EmailDuplicateException _:
                    case PasswordMismatchException _:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case NotFoundException _:
                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
            }

            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("exception", "validationException");
            var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
            await context.Response.WriteAsync(errorJson);
        }
    }
}
