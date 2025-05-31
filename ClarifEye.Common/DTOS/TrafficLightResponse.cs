using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClarifEye.Common.DTOS
{
    public class TrafficLightResponse
    {
        [JsonPropertyName("predicted_class")]
        public int PredictedClass { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
