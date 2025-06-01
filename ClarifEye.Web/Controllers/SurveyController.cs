using ClarifEye.Data.Models;
using ClarifEye.Infrastructure.Implementations;
using ClarifEye.Infrastructure.Interfaces;
using ClarifEye.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace ClarifEye.Web.Controllers
{
    public class SurveyController(ISurveyService surveyService, UserManager<ClarUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            SurveyViewModel model = new SurveyViewModel();
            model.FirstPart = await surveyService.GetFirstPartOfSurvey();
            model.SecondPart = await surveyService.GetSecondPartOfSurvey();
            model.ThirdPart = await surveyService.GetThirdPartOfSurvey();
            model.FourthPart = await surveyService.GetFourthtPartOfSurvey();
            model.FifthPart = await surveyService.GetFifthPartOfSurvey();
            return View(model); //Implement the View
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSurvey(SurveyViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var firstInput = model.ScaleAnswers.Select(x => (x.QuestionId, x.Answer)).ToList();
            var secondInput = model.YesNoAnswers.Select(x => (x.QuestionId, x.Answer)).ToList();
            await surveyService.SaveSurvey(user.Id, firstInput, secondInput, model.ChoiceAnswerIds);

            return RedirectToAction("Index", "Home");
        } 
    }
}
