using Microsoft.AspNetCore.Mvc.Filters;

namespace Company.API.Filters
{
    public class LoggerFilter : IActionFilter
    {
        private readonly ILogger<LoggerFilter> logger;

        public LoggerFilter(ILogger<LoggerFilter> logger)
        {
            this.logger = logger;
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            LoggerExtensions.LogInformation(logger, "Executing action {0}", context.ActionDescriptor.DisplayName);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Executed action {0}", context.ActionDescriptor.DisplayName);
        }

       
    }
}
