using ClarifEye.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models;
public class ClarUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Gender Enum { get; set; }
    public string Occupation { get; set; }
    public ICollection<ChoiceAnswer> ChoosedAnswers = new List<ChoiceAnswer>();
    public ICollection<YesNoAnswer> YesNoAnswers = new List<YesNoAnswer>();
    public ICollection<ScaleAnswer> ScaleAnswers = new List<ScaleAnswer>();
}
