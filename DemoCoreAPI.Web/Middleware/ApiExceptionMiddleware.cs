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
                if (context.Response.HasStarted)
                {
                    throw;
                }
                switch (ex)
                {
                    case ArgumentNullException _:
                    case ArgumentException _:
                    case EmailDuplicateException _:
                    case PasswordMismatchException _:
                        context.Response.StatusCode = 400;
                        break;
                    case NotFoundException _:
                        context.Response.StatusCode = 404;
                        break;
                    default:
                        context.Response.StatusCode = 500;
                        break;
                }
                Log.Error(ex, null);
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "serverException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}
