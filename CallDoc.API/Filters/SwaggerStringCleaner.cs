using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Filters
{
    public class SwaggerStringCleaner : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           

            return;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }
    }
}
