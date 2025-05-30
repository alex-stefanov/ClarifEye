using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class MultipleChoiceQuestion
    {
        [Key]
        public int MultipleChoiceQuestionId { get; set; }
        public string QuestionString { get; set; }
        public HashSet<Choice> Choices = new HashSet<Choice>();
    }
}
