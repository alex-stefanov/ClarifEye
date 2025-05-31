using ClarifEye.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClarifEye.Data.Models;

public class ScaleQuestion
{
    [Key]
    public int ScaleQuestionId { get; set; }
    public string QuestionText { get; set; }

}

