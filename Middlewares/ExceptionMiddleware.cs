using System.Net;
using System.Text.Json;
using ServidorPublico.API.Models;

namespace ServidorPublico.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // continua o pipeline
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string mensagemAmigavel;

        switch (exception)
        {
            case ArgumentException:
            case InvalidOperationException:
                statusCode = HttpStatusCode.BadRequest;
                mensagemAmigavel = exception.Message;
                break;

            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                mensagemAmigavel = exception.Message;
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                mensagemAmigavel = "Ocorreu um erro interno no servidor.";
                break;
        }

        var response = new ErrorResponse
        {
            Status = (int)statusCode,
            Message = mensagemAmigavel
        };

        var json = JsonSerializer.Serialize(response);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(json);
    }
}
