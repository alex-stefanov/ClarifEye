using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class ChoiceConfiguration
         : IEntityTypeConfiguration<Choice>
{
    public void Configure(EntityTypeBuilder<Choice> builder)
    {
        builder.HasData(this.GenerateChoices());
    }

    public IEnumerable<Choice> GenerateChoices()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/choice.json");

        var choices = JsonConvert.DeserializeObject<List<Choice>>(json)
            ?? throw new Exception("Invalid json file path");

        return choices;
    }
}
