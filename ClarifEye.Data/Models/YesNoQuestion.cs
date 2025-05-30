using ClarifEye.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class YesNoQuestion
    {
        [Key]
        public int YesNoQuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<YesNoEnum> Options = new List<YesNoEnum>();
    }
}
