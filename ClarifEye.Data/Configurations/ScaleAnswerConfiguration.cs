using ClarifEye.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace ClarifEye.Data.Configurations;

public class ScaleAnswerConfiguration
        : IEntityTypeConfiguration<ScaleAnswer>
{
    public void Configure(EntityTypeBuilder<ScaleAnswer> builder)
    {
        builder.HasData(this.GenerateScaleAnswers());
    }

    public IEnumerable<ScaleAnswer> GenerateScaleAnswers()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory);
        var json = File.ReadAllText($"{projectDirectory}/ClarifEye.Data/Seed/scaleAnswer.json");

        var scaleAnswers = JsonConvert.DeserializeObject<List<ScaleAnswer>>(json)
            ?? throw new Exception("Invalid json file path");

        return scaleAnswers;
    }
}

