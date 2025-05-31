using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClarifEye.Common.DTOS
{
    public class ColorDetectorResponse
    {
        [JsonPropertyName("prediction")]
        public string Prediction { get; set; }
    }
}
