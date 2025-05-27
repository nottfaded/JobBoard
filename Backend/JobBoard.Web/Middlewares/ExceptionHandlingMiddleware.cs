namespace JobBoard.Web.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            var errorResponse = new
            {
                context.Response.StatusCode,
                Message = "An unexpected error occurred.",
                Details = ex.Message
            };
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}