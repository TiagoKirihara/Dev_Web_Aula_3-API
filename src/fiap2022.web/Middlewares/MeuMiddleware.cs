using Newtonsoft.Json;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

namespace fiap2022.Middlewares
{
    public class MeuMiddleware
    {
        private RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string request = await FormatRequest(httpContext.Request);
            var logger = new LoggerConfiguration()
                .WriteTo.Logentries("67f75285-0320-4589-b100-4144a3927a02")
                .CreateLogger();

            logger.Information($"requst {request}");

            httpContext.Request.Body.Position = 0;

            //logger.Error();
            //logger.Warning();


            await _next(httpContext);

        }

        private async Task<string> FormatRequest(HttpRequest request)
        {

            //request.EnableRewind();
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var body = Encoding.UTF8.GetString(buffer);

            var message = new
            {
                schema = request.Scheme,
                host = request.Host,
                path = request.Path,
                body = body
            };


            return JsonConvert.SerializeObject(message);
        }
    }



    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UseMeuMiddlwareDeLogs(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }
    }
}
