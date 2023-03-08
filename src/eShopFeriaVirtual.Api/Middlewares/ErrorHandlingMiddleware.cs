using eShopFeriaVirtual.Application.Exceptions;
using eShopFeriaVirtual.Application.Wrapper;
using System.Text.Json;

namespace eShopFeriaVirtual.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() {  Success = false, Message = error?.Message };

                switch (error)
                {
                    case AppValidationException e:
                        response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case ApiException e:
                        response.StatusCode = (int)StatusCodes.Status400BadRequest;
                        break;
                    case ResourceNotFoundException e:
                        response.StatusCode = (int)StatusCodes.Status404NotFound;
                        break;
                    default:
                        response.StatusCode = (int)StatusCodes.Status500InternalServerError;
                        break;
                }
                
                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                
                var result = JsonSerializer.Serialize(responseModel, serializerOptions);
                await response.WriteAsync(result);
            }
        }
    }
}
