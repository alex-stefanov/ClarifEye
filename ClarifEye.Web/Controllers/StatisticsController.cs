using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ClarifEye.Web.Controllers
{
    public class StatisticsController(IStasticsService statisticsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            StatisticsViewModel model = new StatisticsViewModel();
            model.Questions = await statisticsService.GetAllQuestions();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FetchData(string question)
        {
            var result = await statisticsService.FetchQuestionData(question);
            return Json(new { received = result });
        }
    }
}
