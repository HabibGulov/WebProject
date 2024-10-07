using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class AgeCheckMiddleware
{
    private readonly RequestDelegate _next;

    public AgeCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("Age", out var ageString) || 
            !int.TryParse(ageString, out var age) || age < 18)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsync("Доступ запрещен. Вы должны быть старше 18 лет.");
            return;
        }
        await _next(context);
    }
}
