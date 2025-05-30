using ClarifEye.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class ScaleAnswer
    {
        [Key]
        public int ScaleAnswerId { get; set; }
        public ScaleEnum SelectedOption { get; set; } //Selected Answer
        [ForeignKey(nameof(ScaleQuestion))]
        public int ScaleQuestionId { get; set; }
        public ScaleQuestion ScaleQuestion { get; set; }
        [ForeignKey(nameof(ClarUser))]
        public string ClarUserId { get; set; }
        public ClarUser User { get; set; }
    }
}
