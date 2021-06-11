using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace CallDoc.API.Midlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            #region Log to file

            var line = Environment.NewLine + Environment.NewLine;
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);

            string ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            string Errormsg = ex.GetType().Name.ToString();
            string extype = ex.GetType().ToString();
            string ErrorLocation = trace.GetFrame(0).GetMethod().ReflectedType.FullName;

            try
            {
                string filepath = Startup.AppRoot + "\\ErrorLogs\\";

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();

                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("----------------- Exception Details on " + " " + DateTime.Now.ToString() + " ------------------");
                    sw.WriteLine("------------------------------------------------------------------------------" + line);
                    //sw.WriteLine("Log Written Date:" + " " + DateTime.Now.ToString() + line);
                    sw.WriteLine("Error Location :" + " " + ErrorLocation);
                    sw.WriteLine("Error Line No :" + " " + ErrorlineNo);
                    sw.WriteLine("Exception Type:" + " " + extype);
                    sw.WriteLine("Error Message:" + " " + Errormsg + line);
                    sw.WriteLine("--------------------------------*End*-----------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }

            }
            catch (Exception e)
            {
                e.ToString();

            }


            #endregion

            ErorrModel problem = new ErorrModel()
            {
                Title = "Internal Server Error",
                Detail = ex.Message,
                Status = (int)statusCode
            };

            string result = JsonConvert.SerializeObject(
                problem,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }

    }

    class ErorrModel
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Status { get; set; }
    }
}
