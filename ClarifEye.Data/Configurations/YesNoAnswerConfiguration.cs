using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

    public class YesNoAnswerConfiguration
        : IEntityTypeConfiguration<YesNoAnswer>
{
    public void Configure(EntityTypeBuilder<YesNoAnswer> builder)
    {
        builder.HasData(this.GenerateYesNoAnswers());
    }

    public IEnumerable<YesNoAnswer> GenerateYesNoAnswers()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/yesNoAnswer.json");

        var yesNoAnswers = JsonConvert.DeserializeObject<List<YesNoAnswer>>(json)
            ?? throw new Exception("Invalid json file path");

        return yesNoAnswers;
    }
}

