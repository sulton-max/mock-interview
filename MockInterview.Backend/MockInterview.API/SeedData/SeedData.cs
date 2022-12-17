using MockInterview.DAL.Contexts;

namespace MockInterview.API.SeedData;

/// <summary>
/// Provides method to use seed data in Database
/// </summary>
public static class SeedData
{
    /// <summary>
    /// Initializes seed data
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void InitializeSeedData(this IServiceProvider serviceProvider)
    {
        var hostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

        if (dbContext == null)
            throw new InvalidOperationException();
    }
}