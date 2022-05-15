using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using UAParser;

namespace LeapYear.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FirefoxRedirection
    {
        private readonly RequestDelegate _next;

        public FirefoxRedirection(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var uaString = httpContext.Request.Headers["User-Agent"];
            var parser = Parser.GetDefault();

            ClientInfo c = parser.Parse(uaString);
            string browser = c.UA.Family;
            
            if(browser == "Edge" || browser=="IE" || browser=="Chrome") 
            {
                httpContext.Response.Redirect($"https://www.mozilla.org/pl/firefox/new/");
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class FirefoxRedirectionExtensions
    {
        public static IApplicationBuilder UseFirefoxRedirection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirefoxRedirection>();
        }
    }
}
