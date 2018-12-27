using Insolation.Forum.Api.Common.Exceptions.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Insolation.Forum.Api.Filter
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Exception ex = actionExecutedContext.Exception;
            HttpResponseMessage errorResponse = new HttpResponseMessage();

            if (ex is SecurityException)
                errorResponse.StatusCode = HttpStatusCode.Unauthorized;
            else
                errorResponse.StatusCode = HttpStatusCode.BadRequest;

            errorResponse.Content = new StringContent(ex.Message);
            actionExecutedContext.Response = errorResponse;

            base.OnException(actionExecutedContext);
        }
    }
}