using ClarifEye.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Data.Models
{
    public class YesNoQuestion
    {
        public string QuestionText { get; set; }
        public YesNoEnum Options { get; set; }
    }
}
