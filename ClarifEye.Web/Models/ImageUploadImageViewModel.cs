using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClarifEye.Web.Models;
public class ImageUploadViewModel
{
    [Required]
    [Display(Name = "Upload Image")]
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
}
