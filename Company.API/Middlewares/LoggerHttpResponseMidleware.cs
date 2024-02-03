using System.Text;

namespace Company.API.Middlewares
{

    public static class LoggerHttpResponseMidlewareExtensions
    {
        public static IApplicationBuilder UseLoggerHttpResponseMidleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggerHttpResponseMidleware>();
        }
    }

    public class LoggerHttpResponseMidleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggerHttpResponseMidleware> logger;

        public LoggerHttpResponseMidleware(RequestDelegate next, ILogger<LoggerHttpResponseMidleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        ///
        public async Task InvokeAsync(HttpContext context)
        {
            await using (var ms = new MemoryStream())
            {
               
                var body = context.Response.Body;
                context.Response.Body = ms;
                await next(context);
                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(body);
                string responseBody = Encoding.UTF8.GetString(ms.ToArray());
                logger.LogInformation(responseBody);
                context.Response.Body = body;
            }
        }

    }
}
