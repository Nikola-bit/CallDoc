using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CallDoc.DTO
{
    public class ApiResponse<T>
    {
        public string message { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public T response { get; set; }

        public static ObjectResult Success(T data)
        {
            return new ObjectResult(new ApiResponse<T>()
            {
                message = "Success",
                statusCode = HttpStatusCode.OK,
                response = data
            });
        }

        public static ObjectResult NotFound(string message = "Not Found")
        {
            return new ObjectResult(new ApiResponse<T>()
            {
                message = message,
                statusCode = HttpStatusCode.NotFound,
                response = default(T)
            });
        }

        public static ObjectResult BadRequest(string message = "Bad request! Missing items!")
        {
            return new ObjectResult(new ApiResponse<T>()
            {
                message = message,
                statusCode = HttpStatusCode.BadRequest,
                response = default(T)
            });
        }
    }
}
