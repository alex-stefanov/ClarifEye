using ClarifEye.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClarifEye.Data.Models;
public class ClarUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }

    [Required]
    public bool IsFilled { get; set; }
    public string Occupation { get; set; }

    public ICollection<ChoiceAnswer> ChoosedAnswers = new List<ChoiceAnswer>();

    public ICollection<YesNoAnswer> YesNoAnswers = new List<YesNoAnswer>();

    public ICollection<ScaleAnswer> ScaleAnswers = new List<ScaleAnswer>();
}
