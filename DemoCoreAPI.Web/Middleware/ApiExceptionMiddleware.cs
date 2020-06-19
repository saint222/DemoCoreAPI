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
            catch (ArgumentNullException ex)
            {
                Log.Error(ex, "ArgumentNullException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "validationException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, "ArgumentException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "validationException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
            catch (EmailDuplicateException ex)
            {
                Log.Error(ex, "EmailDuplicateException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "validationException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
            catch (PasswordMismatchException ex)
            {
                Log.Error(ex, "PasswordMismatchException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "validationException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
            catch (NotFoundException ex)
            {
                Log.Error(ex, "NotFoundException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "validationException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "ServerException.");
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("exception", "serverException");
                var errorJson = JsonConvert.SerializeObject(new { message = ex.Message, stackTrace = ex.StackTrace }, _jsonSettings);
                await context.Response.WriteAsync(errorJson);
            }
        }
    }
}
