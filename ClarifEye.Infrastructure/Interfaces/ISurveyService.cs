using ClarifEye.Data.Enums;

namespace ClarifEye.Infrastructure.Interfaces;

public interface ISurveyService
{
    Task SaveSurvey(
        string userId,
        List<(int questionId, ScaleEnum answer)> scaleQuestionAnswers,
        List<(int questionId, YesNoEnum answer)> yesNoQuestionAnswers,
        List<int> choiseQuestionAnswers);
}
