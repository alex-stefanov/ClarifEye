using ClarifEye.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class ScaleQuestion
    {
        public string QuestionText { get; set; }
        public ScaleEnum Options { get; set; }
    }
}
