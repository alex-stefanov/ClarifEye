using System.Reflection;
using ClarifEye.Data.Models;
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
                "Server=DESKTOP-S220U88\\SQLEXPRESS;Database=ClarifEye;Integrated Security=true;TrustServerCertificate=true;");
        }
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }

    public DbSet<ClarUser> Users { get; set; }
    public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<ChoiceAnswer> ChoiceAnswers { get; set; }
    public DbSet<ScaleQuestion> ScaleQuestions { get; set; }
    public DbSet<ScaleAnswer> ScaleAnswers { get; set; }
    public DbSet<YesNoQuestion> YesNoQuestions { get; set; }
    public DbSet<YesNoAnswer> YesNoAnswers { get; set; }
}
