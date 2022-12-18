using AutoMapper;
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

        var selectionItemsData =
            JsonConvert.DeserializeObject<IEnumerable<SelectionItem>>(File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "SelectionItemsData.json")))!;

        dbContext.SelectionItems.AddRange(selectionItemsData);
        dbContext.SaveChanges();
    }

    private static void SeedRoles(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.UserRoles.Any())
            return;

        var userRolesData = JsonConvert.DeserializeObject<IEnumerable<UserRole>>(File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "UserRolesData.json")))!;

        dbContext.UserRoles.AddRange(userRolesData);
        dbContext.SaveChanges();
    }

    private static void SeedUsers(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
    {
        if (dbContext.Users.Any())
            return;

        var usersData = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "UsersData.json")))!;

        var talentsData = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(File.ReadAllText(Path.Combine(hostEnvironment.ContentRootPath, "SeedData", "Data", "TalentsData.json")))!;

        var users = usersData.Select(x => new User
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            EmailAddress = x.EmailAddress,
            Gender = x.Gender,
            DateOfBirth = DateTime.Parse(x.DateOfBirth.ToString()),
            Password = x.Password
        });

        dbContext.Users.AddRange(users);

        var talents = talentsData.Select(x => new Talent
        {
            Level = x.Level,
            Experience = int.Parse(x.Experience.ToString()),
            Projects = x.Projects,
        });

        dbContext.Talents.AddRange(talents);
        dbContext.SaveChanges();

        var savedUsers = dbContext.Users.ToList();
        var savedTalents = dbContext.Talents.ToList();

        for (var index = 0; index < savedTalents.Count; index++)
        {
            savedUsers[index].TalentId = savedTalents[index].Id;

            dbContext.Users.Update(savedUsers[index]);
            dbContext.Talents.Update(savedTalents[index]);

            // TODO : Remove
            var random = new Random();
            if (random.Next(0, 2) == 1)
                dbContext.Interviewers.Add(new Interviewer
                {
                    UserId = savedUsers[index].Id
                });
        }

        dbContext.SaveChanges();
    }
}