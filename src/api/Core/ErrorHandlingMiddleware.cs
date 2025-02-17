namespace TesteTecFullstackAngular.Api.Core
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                httpContext.Response.StatusCode = ex.StatusCode;
                httpContext.Response.ContentType = "application/json";

                var response = new { Error = ex.Message, ErrorCode = ex.ErrorCode };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ContentType = "application/json";

                var response = new { Error = "Ocorreu um erro interno.", Details = ex.Message };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
