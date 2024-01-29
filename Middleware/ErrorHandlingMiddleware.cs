using MongoDB.Driver;
using Npgsql;

namespace Survey.Api.Cloud.Core.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate _next, ILogger<ErrorHandlingMiddleware> _logger)
        {
            next =  _next;
            logger =  _logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);

            }
            catch (MongoException ex)
            {
                logger.LogError($"MongoDB Exception: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"MongoDB Error: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                logger.LogError($"PostgreSQL Exception: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"PostgreSQL Error: {ex.Message}");
            }
            catch (InvalidDataException ex)
            {
                logger.LogError($"InvalidData Exception: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Exception: {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Error: {ex.Message}");
            }
        }
    }
}
