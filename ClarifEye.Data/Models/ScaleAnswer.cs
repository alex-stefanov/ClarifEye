using ClarifEye.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarifEye.Data.Models;

public class ScaleAnswer
{
    [Key]
    public int ScaleAnswerId { get; set; }
    public ScaleEnum SelectedOption { get; set; }
    [ForeignKey(nameof(ScaleQuestion))]
    public int ScaleQuestionId { get; set; }
    public ScaleQuestion ScaleQuestion { get; set; }
    [ForeignKey(nameof(ClarUser))]
    public string ClarUserId { get; set; }
    public ClarUser User { get; set; }
}

