using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
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
}
