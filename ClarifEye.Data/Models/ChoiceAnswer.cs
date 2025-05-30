using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class ChoiceAnswer
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Choice))]
        public int ChoiceId { get; set; } //Choosed Answer
        public Choice Choice { get; set; }
        [ForeignKey(nameof(ClarUser))]
        public int UserId { get; set; }
        public ClarUser User { get; set; }
    }
}
