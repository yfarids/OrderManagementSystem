using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OrderManagement.API.Filters;

public class AuditFilter : IActionFilter
{
    private ILogger<AuditFilter> _logger;
    private readonly Stopwatch _stopwatch;
    
    public AuditFilter(ILogger<AuditFilter> logger, Stopwatch stopwatch)
    {
        _logger = logger;
        _stopwatch = stopwatch;
    }
    
    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Restart();
        _logger.LogInformation("Action {Action} started", context.ActionDescriptor.DisplayName);
    }
    
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
         var elapsedMs = _stopwatch.ElapsedMilliseconds;
        _logger.LogInformation("Action {Action} finished in {EllapsedMilliseconds} ms",
        context.ActionDescriptor.DisplayName,
        elapsedMs);
    }


}
