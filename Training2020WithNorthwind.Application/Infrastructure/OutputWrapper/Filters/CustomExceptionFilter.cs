using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Exceptions;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Filters
{
    /// <summary>
    /// CustomExceptionFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter"/>
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var isValidateException = context.Exception is ValidateException;

            if (isValidateException.Equals(false))
            {
                var result = new FailureResultOutputModel
                {
                    Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                    Status = "Exception",
                    Errors = new List<FailureInformation>
                    {
                        new FailureInformation
                        {
                            ErrorCode = 30001,
                            Message = context.Exception.Message,
                            Description = context.Exception.ToString()
                        }
                    }
                };

                context.Result = new ObjectResult(result)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                context.ExceptionHandled = true;

                await Task.Yield();
            }
        }
    }
}