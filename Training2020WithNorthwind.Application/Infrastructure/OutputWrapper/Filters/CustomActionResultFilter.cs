using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models;

namespace Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Filters
{
    /// <summary>
    /// CustomActionResultFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter" />
    public class CustomActionResultFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        /// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate" />. Invoked to execute the next action filter or the action itself.</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executedContext = await next();

            if (executedContext.Result is ObjectResult result)
            {
                switch (result.Value)
                {
                    case HttpResponseMessage _:
                        return;
                    case SuccessResultOutputModel<object> _:
                        return;
                    case FailureResultOutputModel _:
                        return;
                }

                var controllerTypeName = context.Controller.GetType().Name;

                if (controllerTypeName.Equals("ActionController", StringComparison.OrdinalIgnoreCase).Equals(false))
                {
                    var httpMethod = context.HttpContext.Request.Method;

                    if (result.StatusCode >= 400)
                    {
                        var failureResponse = new FailureResultOutputModel
                        {
                            Method = $"{context.HttpContext.Request.Path}.{httpMethod}",
                            Status = "Faliure",
                            Errors = new List<FailureInformation> { (FailureInformation)result.Value }
                        };

                        executedContext.Result = new ObjectResult(failureResponse)
                        {
                            StatusCode = result.StatusCode
                        };
                    }
                    else
                    {
                        var successResponse = new SuccessResultOutputModel<object>
                        {
                            Method = $"{context.HttpContext.Request.Path}.{httpMethod}",
                            Status = "Success",
                            Data = result.Value
                        };

                        executedContext.Result = new ObjectResult(successResponse)
                        {
                            StatusCode = result.StatusCode
                        };
                    }
                }
            }
        }
    }
}