using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialNet.WebApi.Infrastructure.Helpers.Filters
{
    public class ActionInfoLogFilter : IActionFilter
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.Info("After executing action {action} with parameters {@parameters}", context.ActionDescriptor.DisplayName, context.ActionDescriptor.Parameters);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.Info("Before executing action {action} with parameters {@parameters}", context.ActionDescriptor.DisplayName, context.ActionDescriptor.Parameters);
        }
    }
}
