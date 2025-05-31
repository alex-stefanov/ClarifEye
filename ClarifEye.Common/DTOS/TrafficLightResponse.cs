using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Common.DTOS
{
    public class TrafficLightResponse
    {
        public string Predicted_Class { get; set; }
        public string Color { get; set; }
    }
}
