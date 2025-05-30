using ClarifEye.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class ScaleQuestion
    {
        [Key]
        public int ScaleQuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<ScaleEnum> Options = new List<ScaleEnum>();
    }
}
