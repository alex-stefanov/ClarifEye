using ClarifEye.Data.Enums;
using ClarifEye.Data.Models;
using ClarifEye.Data.Repository.Interfaces;
using ClarifEye.Infrastructure.Interfaces;

namespace ClarifEye.Infrastructure.Implementations;

public class SurveyService(
    IRepository<ChoiceAnswer, int> cARepository,
    IRepository<ScaleAnswer, int> sARepository,
    IRepository<YesNoAnswer, int> yNARepository)
    : ISurveyService
{
    public async Task SaveSurvey(
        string userId,
        List<(int questionId, ScaleEnum answer)> scaleQuestionAnswers,
        List<(int questionId, YesNoEnum answer)> yesNoQuestionAnswers,
        List<int> choiseQuestionAnswers)
    {
        foreach (var item in scaleQuestionAnswers)
        {
            await sARepository.AddAsync(new ScaleAnswer
            {
                ScaleQuestionId = item.questionId,
                ClarUserId = userId,
                SelectedOption = item.answer,
            });
        }

        foreach (var item in yesNoQuestionAnswers)
        {
            await yNARepository.AddAsync(new YesNoAnswer
            {
                YesNoQuestionId = item.questionId,
                ClarUserId = userId,
                SelectedOption = item.answer,
            });
        }

        foreach (var item in choiseQuestionAnswers)
        {
            await cARepository.AddAsync(new ChoiceAnswer
            {
                ChoiceId = item,
                UserId = userId
            });
        }
    }
}