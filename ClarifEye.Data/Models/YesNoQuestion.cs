using ClarifEye.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClarifEye.Data.Models;

public class YesNoQuestion
{
    [Key]
    public int YesNoQuestionId { get; set; }
    public string QuestionText { get; set; }
}

