using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarifEye.Data.Models;

public class Choice
{
    [Key]
    public int ChoiceId { get; set; }
    public string AnswerString { get; set; }

    [ForeignKey(nameof(MultipleChoiceQuestion))]
    public int MultipleChoiceQuestionId { get; set; }
    public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

    public ICollection<ChoiceAnswer> ChoiceAnswers = new HashSet<ChoiceAnswer>();
}

