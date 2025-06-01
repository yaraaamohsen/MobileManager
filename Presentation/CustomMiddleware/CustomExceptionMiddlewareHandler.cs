using Application.DTOs;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Presentation.CustomMiddleware
{
    public class CustomExceptionMiddlewareHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddlewareHandler> _logger;

        public CustomExceptionMiddlewareHandler(RequestDelegate next, ILogger<CustomExceptionMiddlewareHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext _context)
        {
            try
            {
                await _next.Invoke(_context);

                // Handdling Unauthorized Exception
                if (_context.Response.StatusCode == StatusCodes.Status401Unauthorized && !_context.Response.HasStarted)
                {
                    _context.Response.ContentType = "application/json";
                    var response = new BaseResponse<object>("Unauthorized Access");
                    await _context.Response.WriteAsJsonAsync(response);
                }

                // Handling NotFound EndPoint Exception
                if (_context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    _context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    var response = new BaseResponse<object>("Please re-try again, if the error persist please contact Administrator");
                    await _context.Response.WriteAsJsonAsync(response);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Please re-try again, if the error persist please contact Administrator");
                await HandleExceptionAsync(_context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext _context, Exception ex)
        {
            _context.Response.StatusCode = ex switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            _context.Response.ContentType = "application/json";

            var responseMessage = ex switch
            {
                ValidationException => ex.Message,
                UnauthorizedException => ex.Message,
                _ => "Please re-try again, if the error persist please contact Administrator"
            };
            var Response = new BaseResponse<object>(responseMessage);

            await _context.Response.WriteAsJsonAsync(Response);
        }
    }
}
