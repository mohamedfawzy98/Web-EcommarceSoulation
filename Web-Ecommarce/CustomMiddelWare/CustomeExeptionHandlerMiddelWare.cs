using ServicesAbstarction.ExcaptionErrors;
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

                // Handle NotFound EndPoints
                await HandleEndPointNotFountAsync(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            // Set the response status code
            context.Response.StatusCode = ex switch
            {
                NotFoundExeption => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            //context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //Return Object
            var Response = new ErrorToReturn
            {
                StatusCode = context.Response.StatusCode,
                Messages = ex.Message
            };
            // Write the error response as JSON
            await context.Response.WriteAsJsonAsync(Response);
        }

        private static async Task HandleEndPointNotFountAsync(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var Response = new ErrorToReturn
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Messages = $"The End Point {context.Request.Path}  Was Not Found."
                };
                await context.Response.WriteAsJsonAsync(Response);
            }
        }
    }
}
