using ClarifEye.Data.Enums;
using ClarifEye.Data.Models;
using ClarifEye.Data.Repository.Interfaces;

namespace ClarifEye.Infrastructure.Interfaces;

public interface ISurveyService
{
    Task SaveSurvey(
        string userId,
        List<(int questionId, ScaleEnum answer)> scaleQuestionAnswers,
        List<(int questionId, YesNoEnum answer)> yesNoQuestionAnswers,
        List<int> choiseQuestionAnswers);
    public Task<List<ScaleQuestion>> GetFirstPartOfSurvey();
    public Task<List<ScaleQuestion>> GetSecondPartOfSurvey();

    public Task<List<ScaleQuestion>> GetThirdPartOfSurvey();

    public Task<List<YesNoQuestion>> GetFourthtPartOfSurvey();

    public Task<(MultipleChoiceQuestion mCQuestion, YesNoQuestion yNQuestion)> GetFifthPartOfSurvey();
}
