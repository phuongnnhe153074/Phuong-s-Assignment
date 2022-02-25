namespace Assignment_Entity_2.Common;
using System;
using System.Diagnostics;
using System.Text.Json;

public class InitializeDatabaseMiddleware
{
    private readonly RequestDelegate _next;

    public InitializeDatabaseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        


        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class InitializeDatabaseMiddlewareExtensions
{
    public static IApplicationBuilder InitializeDatabaseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InitializeDatabaseMiddleware>(builder);
    }
}