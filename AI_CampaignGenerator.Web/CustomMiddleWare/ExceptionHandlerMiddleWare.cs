using AI_CampaignGenerator.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AI_CampaignGenerator.Web.CustomMiddleWare
{
    
        public class ExceptionHandlerMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly ILogger<ExceptionHandlerMiddleware> _logger;

            public ExceptionHandlerMiddleware(
                RequestDelegate next,
                ILogger<ExceptionHandlerMiddleware> logger)
            {
                _next = next;
                _logger = logger;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                if(context.Response.StatusCode==StatusCodes.Status404NotFound&&!context.Response.HasStarted)
                {
                    await HandleNotFoundEndpointAsync(context);
                }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unhandled Exception");

                    var problem = new ProblemDetails
                    {
                        Title = "Error While Processing Request",
                        Detail = ex.Message,
                        Instance = context.Request.Path,
                        Status = ex switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        }
                    };

                    context.Response.StatusCode = problem.Status.Value;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsJsonAsync(problem);
                }
            }

            private static async Task HandleNotFoundEndpointAsync(HttpContext context)
            {
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var problem = new ProblemDetails
                    {
                        Title = "Endpoint Not Found",
                        Detail = $"Endpoint {context.Request.Path} not found.",
                        Status = StatusCodes.Status404NotFound,
                        Instance = context.Request.Path
                    };

                    await context.Response.WriteAsJsonAsync(problem);
                }
            }
        }
    
}
