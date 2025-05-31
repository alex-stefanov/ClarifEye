using ClarifEye.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarifEye.Data.Models;

public class YesNoAnswer
{
    [Key]
    public int YesNoAnswerId { get; set; }
    public YesNoEnum SelectedOption { get; set; }
    [ForeignKey(nameof(YesNoQuestion))]
    public int YesNoQuestionId { get; set; }
    public YesNoQuestion YesNoQuestion { get; set; }
    [ForeignKey(nameof(ClarUser))]
    public string ClarUserId { get; set; }
    public ClarUser User { get; set; }

}

