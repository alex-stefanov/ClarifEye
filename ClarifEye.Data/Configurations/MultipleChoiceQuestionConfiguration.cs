using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class MultipleChoiceQuestionConfiguration
    : IEntityTypeConfiguration<MultipleChoiceQuestion>
{
    public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
    {
        builder.HasData(this.GenerateMultipleChoiceQuestions());
    }

    public IEnumerable<MultipleChoiceQuestion> GenerateMultipleChoiceQuestions()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/multipleChoiceQuestion.json");

        var multipleChoiceQuestions = JsonConvert.DeserializeObject<List<MultipleChoiceQuestion>>(json)
            ?? throw new Exception("Invalid json file path");

        return multipleChoiceQuestions;
    }

}

