using Microsoft.EntityFrameworkCore;

namespace MockInterview.DAL.Contexts;

/// <summary>
/// Represent General DbContext
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}