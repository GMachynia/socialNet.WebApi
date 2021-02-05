using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;

namespace socialNet.WebApi.Infrastructure.Helpers.Filters
{
    public class ExceptionLogFilter : IExceptionFilter
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null)
            {
                logger.Error("In {classLogger} catched exeption: {err}", context.ActionDescriptor.DisplayName, context.Exception.Message);
                context.Result = new BadRequestObjectResult(context.Exception.Message);
            }
        }
    }
}
