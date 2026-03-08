using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace MusicLibrary.ApiService.Exceptions;

/// <summary>
/// Handles global exceptions and writes problem details responses.
/// </summary>
internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
    /// </summary>
    /// <param name="problemDetailsService">The problem details service.</param>
    /// <param name="logger">The logger instance.</param>
    public GlobalExceptionHandler(
        IProblemDetailsService problemDetailsService,
        ILogger<GlobalExceptionHandler> logger)
    {
        _problemDetailsService = problemDetailsService;
        _logger = logger;
    }

    /// <summary>
    /// Handles exceptions and writes a problem details response.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the exception was handled; otherwise, false.</returns>
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Unhandled exception occurred");

        httpContext.Response.StatusCode = exception switch
        {
            ApplicationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = new ProblemDetails
            {
                Type = exception.GetType().Name,
                Title = "An error occured",
                Detail = exception.Message
            }
        });
    }
}


