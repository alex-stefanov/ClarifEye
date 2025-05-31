using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class ScaleQuestionConfiguration
    : IEntityTypeConfiguration<ScaleQuestion>
{
    public void Configure(EntityTypeBuilder<ScaleQuestion> builder)
    {
        builder.HasData(this.GenerateScaleQuestion());
    }

    public IEnumerable<ScaleQuestion> GenerateScaleQuestion()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/scaleQuestion.json");

        var scaleQuestions = JsonConvert.DeserializeObject<List<ScaleQuestion>>(json)
            ?? throw new Exception("Invalid json file path");

        return scaleQuestions;
    }
}

