using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class ChoiceAnswerConfiguration
    : IEntityTypeConfiguration<ChoiceAnswer>
{
    public void Configure(EntityTypeBuilder<ChoiceAnswer> builder)
    {
        builder.HasData(this.GenerateChoicesAnswers());
    }

    public IEnumerable<ChoiceAnswer> GenerateChoicesAnswers()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/choiceAnswer.json");

        var choicesAnswers = JsonConvert.DeserializeObject<List<ChoiceAnswer>>(json)
            ?? throw new Exception("Invalid json file path");

        return choicesAnswers;
    }
}

