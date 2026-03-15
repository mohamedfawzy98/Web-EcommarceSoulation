using Shared.ErrorModels;

namespace Web_Ecommarce.CustomMiddelWare
{
    public class CustomeExeptionHandlerMiddelWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomeExeptionHandlerMiddelWare> _logger;

        public CustomeExeptionHandlerMiddelWare(RequestDelegate Next, ILogger<CustomeExeptionHandlerMiddelWare> logger)
        {
            _next = Next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unhandled exception occurred.");
                // Set the response status code
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                //Return Object
                var Response = new ErrorToReturn
                {
                    StatusCode = context.Response.StatusCode,
                    Messages = "An unexpected error occurred. Please try again later."
                };
                // Write the error response as JSON
                await context.Response.WriteAsJsonAsync(Response);
            }
        }

    }
}
