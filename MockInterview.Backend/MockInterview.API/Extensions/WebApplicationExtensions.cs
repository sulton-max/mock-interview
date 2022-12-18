using MockInterview.API.SeedData;

namespace MockInterview.API.Extensions;

public static class ProjectWebApplicationExtensions
{
    /// <summary>
    /// Uses Open API tools on the app pipeline
    /// </summary>
    /// <param name="app">Web App</param>
    /// <returns>Web App for method chaining</returns>
    public static WebApplication UseOpenApiTools(this WebApplication app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi3();

        return app;
    }

    /// <summary>
    /// Seeds initial data to Database
    /// </summary>
    /// <param name="app">Web App</param>
    /// <returns>Web App for method chaining</returns>
    public static WebApplication UseSeedData(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        scope.ServiceProvider.InitializeSeedData();

        return app;
    }
}