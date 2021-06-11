using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallDoc.API.Midlewares
{
    public class SwaggerStringCleaner
    {
        private readonly RequestDelegate _next;

        public SwaggerStringCleaner(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST")
            {

                try
                {
                    string bodyAsText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();

                    dynamic stuff = JsonConvert.DeserializeObject(bodyAsText);

                    foreach(var item in stuff)
                    {
                        if(item.Value.Type == typeof(String))
                        {

                        }
                    }

                    //object obj = JsonConvert.DeserializeObject<object>(bodyAsText);

                    //object obj = JObject.Parse(bodyAsText);

                    //httpContext.Request.Body.Position = 0;

                    //JObject objRequestBody = new JObject();

                    //using (StreamReader reader = new StreamReader(
                    //httpContext.Request.Body,
                    //Encoding.UTF8,
                    //detectEncodingFromByteOrderMarks: false,
                    //leaveOpen: true))
                    //{

                    //    string strRequestBody = await reader.ReadToEndAsync();
                    //    objRequestBody = JsonSerializer.Deserialize<JObject>(strRequestBody);
                    //}
                }
                catch (Exception ex)
                {

                } 
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline. 
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseSwaggerStringCleaner(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerStringCleaner>();
        }
    }
}
