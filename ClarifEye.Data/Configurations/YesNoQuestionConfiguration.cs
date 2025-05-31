using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class YesNoQuestionConfiguration
    : IEntityTypeConfiguration<YesNoQuestion>
{
    public void Configure(EntityTypeBuilder<YesNoQuestion> builder)
    {
        builder.HasData(this.GenerateChoicesAnswers());
    }

    public IEnumerable<YesNoQuestion> GenerateChoicesAnswers()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/yesNoQuestion.json");

        var yesNoQuestions = JsonConvert.DeserializeObject<List<YesNoQuestion>>(json)
            ?? throw new Exception("Invalid json file path");

        return yesNoQuestions;
    }
}

