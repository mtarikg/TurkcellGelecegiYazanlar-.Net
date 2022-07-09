using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using nbaDemo.API.Subclasses;
using System;

namespace nbaDemo.API.Filters
{
    public class LogInfo<T> : IActionFilter where T : ControllerBase
    {
        private readonly ILogger<T> logger;
        private string actionName;
        private readonly HangfireMethods hangfireMethods = new();

        public LogInfo(ILogger<T> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            actionName = context.ActionDescriptor.DisplayName;
            var actionResult = context.Result.ToString();
            logger.LogInformation($"The result of {actionName}: {actionResult}");
            hangfireMethods.SetBackgroundJob(actionName, actionResult);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            actionName = context.ActionDescriptor.DisplayName;
            logger.LogInformation($"{actionName} has been executed at: {DateTime.Now}");
        }
    }
}
