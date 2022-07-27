using Microsoft.AspNetCore.Http;

namespace BuscaECondominio.Web.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new {msg = ex.Message} );
            }
        }
    }
}