using System;

namespace OrderManagement.API.Middlewars;

public class ErrorHandlingMiddlewar
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddlewar> _logger;

    public ErrorHandlingMiddlewar(RequestDelegate next, ILogger<ErrorHandlingMiddlewar> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Unhandeled Exception.");

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An error occured.");            
        }
    }
    
    
}
