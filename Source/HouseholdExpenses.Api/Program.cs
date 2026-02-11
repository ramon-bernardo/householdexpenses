using System.Text.Json.Serialization;
using HouseholdExpenses.Api.Common.Middlewares;
using HouseholdExpenses.Application;
using HouseholdExpenses.Infrastructure.Data;

namespace HouseholdExpenses.Api;

public class Program
{
    public static void Main(string[] args)
    {
        // Web Application
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddOpenApi();

        builder.Services
            .AddControllers()
            .AddJsonOptions((options) =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        // Application
        var app = builder.Build();
        app.UseDefaultFiles();
        app.MapStaticAssets();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();
        app.MapFallbackToFile("/index.html");
        app.Run();
    }
}
