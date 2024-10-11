using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ecommerce.Attributes.Exceptions;
using Ecommerce;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Attributes.ExceptionFilters
{
    public class BadRequestExceptionFilter : IExceptionFilter
    {
        private readonly AppConfig _appConfig;

        #region Constructor
        public BadRequestExceptionFilter(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        #endregion

        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(BadRequestException))
            {
                var exceptionResponse = new ExceptionResponse(
                    (string?)context.Exception.Data["Id"],
                    ((int)HttpStatusCode.BadRequest).ToString(),
                    HttpStatusCode.BadRequest.ToString(),
                    context.Exception.Message,
                    string.Empty,
                    _appConfig.StatusCodeHelpRefrence?.BadRequest ?? String.Empty);
                context.Result = new BadRequestObjectResult(exceptionResponse);
                context.ExceptionHandled = true;
            }
        }
    }
}
