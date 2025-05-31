using System.ComponentModel.DataAnnotations;

namespace ClarifEye.Data.Models;

public class MultipleChoiceQuestion
{
    [Key]
    public int MultipleChoiceQuestionId { get; set; }
    public string QuestionString { get; set; }

    public HashSet<Choice> Choices = new HashSet<Choice>();
}

