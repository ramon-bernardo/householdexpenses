using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using HouseholdExpenses.Api.Common.Extensions;
using HouseholdExpenses.Domain.Common;

namespace HouseholdExpenses.Api.Common.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    IHostEnvironment environment
)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DomainException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.MapToStatusCode();

            var problemDetails = CreateProblemDetails(
                status: ex.MapToStatusCode(),
                title: "Domain Error",
                detail: ex.Message,
                errorCode: ex.Code
            );

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = CreateProblemDetails(
                status: StatusCodes.Status400BadRequest,
                title: "Validation Error",
                detail: "One or more validation failures occurred.",
                errorCode: "VALIDATION_FAILED",
                extensions: new Dictionary<string, object?>
                {
                    { "errors", ex.Errors.Select(e => e.ErrorMessage) }
                }
            );

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = CreateProblemDetails(
                status: StatusCodes.Status500InternalServerError,
                title: "Internal Server Error",
                detail: environment.IsDevelopment() ? exception.Message : "An unexpected error occurred.",
                errorCode: "UNEXPECTED_INTERNAL_ERROR"
            );

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ProblemDetails CreateProblemDetails(int status, string title, string detail, string errorCode, IDictionary<string, object?>? extensions = null)
    {
        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail,
            Type = $"https://api.website.com/errors/{errorCode.ToLower().Replace("_", "-")}"
        };

        problem.Extensions.Add("errorCode", errorCode);

        if (extensions is not null)
        {
            foreach (var ext in extensions)
            {
                problem.Extensions.Add(ext.Key, ext.Value);
            }
        }

        return problem;
    }
}
