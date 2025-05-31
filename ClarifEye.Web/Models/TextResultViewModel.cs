using ClarifEye.Common.Enums;

namespace ClarifEye.Web.Models
{
    public class TextResultViewModel
    {
        public string Text { get; set; } = null!;
        public Language? Language { get; set; }
    }
}
