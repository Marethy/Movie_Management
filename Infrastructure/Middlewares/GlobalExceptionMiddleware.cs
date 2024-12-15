namespace WebApplication1.Infrastructure.Middlewares
{
    public class GlobalExceptionMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Chuyển request đến middleware tiếp theo
                await _next(context);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây
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
}
