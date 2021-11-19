using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Exceptions;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Models;

namespace Training2020WithNorthwind.Application.Infrastructure.ActionFilter
{
    /// <summary>
    /// 參數驗證器
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute"/>
    public class RequestParameterValidatorAttribute : ActionFilterAttribute
    {
        private readonly Type _validatorType;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameterValidatorAttribute"/> class.
        /// </summary>
        /// <param name="validatorType">Type of the validator.</param>
        public RequestParameterValidatorAttribute(Type validatorType)
        {
            this._validatorType = validatorType;
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <inheritdoc/>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameters = context.ActionArguments;
            if (parameters.Count <= 0)
            {
                await base.OnActionExecutionAsync(context, next);
            }

            var parameter = parameters.FirstOrDefault();
            if (parameter.Value == null)
            {
                context.Result = new BadRequestObjectResult("未輸入參數");
            }

            var validator = Activator.CreateInstance(this._validatorType) as IValidator;
            if (validator == null)
            {
                throw new ArgumentException($"必須傳入{nameof(validator)}型別");
            }

            var validationResult = await validator.ValidateAsync(parameter.Value);

            if (validationResult.IsValid.Equals(false))
            {
                var error = validationResult.Errors.FirstOrDefault();

                var failureOutputModel = new FailureResultOutputModel
                {
                    Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                    Status = "VaildationError",
                    Errors = new List<FailureInformation>
                    {
                        new FailureInformation
                        {
                            ErrorCode = 30001,
                            Message = "輸入資料驗證錯誤",
                            Description = error.ErrorMessage
                        }
                    }
                };

                context.Result = new BadRequestObjectResult(failureOutputModel);
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}