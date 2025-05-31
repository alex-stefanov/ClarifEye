using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class ClarUserConfiguration
    : IEntityTypeConfiguration<ClarUser>
{
    public void Configure(EntityTypeBuilder<ClarUser> builder)
    {
        builder.HasData(this.GenerateClarUser());
    }

    public IEnumerable<ClarUser> GenerateClarUser()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/clarUser.json");

        var clarUsers = JsonConvert.DeserializeObject<List<ClarUser>>(json)
            ?? throw new Exception("Invalid json file path");

        return clarUsers;
    }
}

