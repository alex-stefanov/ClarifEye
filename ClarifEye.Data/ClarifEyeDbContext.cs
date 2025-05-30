using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClarifEye.Data;

public class ClarifEyeDbContext
    : IdentityDbContext<IdentityUser>
{
    public ClarifEyeDbContext() { }

    public ClarifEyeDbContext(
        DbContextOptions<ClarifEyeDbContext> options)
        : base(options) { }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=Clarify;User Id=sa;Password=Str0ngPa$$w0rd;TrustServerCertificate=True");
        }
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
