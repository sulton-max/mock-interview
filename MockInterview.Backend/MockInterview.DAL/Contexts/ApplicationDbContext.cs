using Microsoft.EntityFrameworkCore;
using MockInterview.Core.Models.Entities;
using MockInterview.DAL.EntityMaps;

namespace MockInterview.DAL.Contexts;

/// <summary>
/// Represent General DbContext
/// </summary>
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Talent> Talents => Set<Talent>();
    public DbSet<Interviewer> Interviewers => Set<Interviewer>();
    public DbSet<SelectionItem> SelectionItems => Set<SelectionItem>();
    public DbSet<Interview> Interviews => Set<Interview>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap())
            .ApplyConfiguration(new ContactMap())
            .ApplyConfiguration(new TalentMap())
            .ApplyConfiguration(new InterviewerMap())
            .ApplyConfiguration(new SelectionItemMap())
            .ApplyConfiguration(new InterviewMap())
            .ApplyConfiguration(new UserRoleMap());
    }
}