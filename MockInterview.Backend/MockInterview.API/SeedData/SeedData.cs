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
    }

    public static void SeedSelectionItems(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.SelectionItems.Any())
            return;

        var selectionItemsData = JsonConvert
            .DeserializeObject<IEnumerable<SelectionItem>>
                (File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "SelectionItemsData.json")))!;

        dbContext.SelectionItems.AddRange(selectionItemsData);
        dbContext.SaveChanges();
    }
}