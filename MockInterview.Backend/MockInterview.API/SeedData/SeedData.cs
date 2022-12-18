using MockInterview.Core.Models.Entities;
using MockInterview.DAL.Contexts;
using Newtonsoft.Json;

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

        SeedSelectionItems(dbContext, hostEnvironment);

        // Add development seed data
        if (hostEnvironment.IsDevelopment())
        {
            SeedRoles(dbContext, hostEnvironment);
            SeedUsers(dbContext, hostEnvironment);
        }
    }

    private static void SeedSelectionItems(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.SelectionItems.Any())
            return;

        var selectionItemsData = JsonConvert
            .DeserializeObject<IEnumerable<SelectionItem>>
                (File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "SelectionItemsData.json")))!;

        dbContext.SelectionItems.AddRange(selectionItemsData);
        dbContext.SaveChanges();
    }

    private static void SeedRoles(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.UserRoles.Any())
            return;

        var userRolesData = JsonConvert
            .DeserializeObject<IEnumerable<UserRole>>
                (File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "UserRolesData.json")))!;
        
        dbContext.UserRoles.AddRange(userRolesData);
        dbContext.SaveChanges();
    }
    
    private static void SeedUsers(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.Users.Any())
            return;

        var usersData = JsonConvert
            .DeserializeObject<IEnumerable<User>>
                (File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "UsersData.json")))!;
        
        dbContext.Users.AddRange(usersData);
        dbContext.SaveChanges();
    }
}