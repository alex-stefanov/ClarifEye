using ClarifEye.Data.Enums;
using ClarifEye.Data.Models;
using ClarifEye.Data.Repository.Interfaces;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClarifEye.Infrastructure.Implementations;

public class SurveyService(
    IRepository<ChoiceAnswer, int> cARepository,
    IRepository<ScaleAnswer, int> sARepository,
    IRepository<YesNoAnswer, int> yNARepository,
    IRepository<ScaleQuestion, int> sQRepository,
    IRepository<YesNoQuestion, int> yNQRepository,
    IRepository<MultipleChoiceQuestion, int> mCQRepository,
    IRepository<Choice, int> cRepository)
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
    public async Task<List<ScaleQuestion>> GetFirstPartOfSurvey() =>
        await sQRepository.GetAllAttached().Where(x => x.ScaleQuestionId < 6).ToListAsync();

    public async Task<List<ScaleQuestion>> GetSecondPartOfSurvey() =>
        await sQRepository.GetAllAttached().Where(x => x.ScaleQuestionId > 5 && x.ScaleQuestionId < 11).ToListAsync();

    public async Task<List<ScaleQuestion>> GetThirdPartOfSurvey() =>
    await sQRepository.GetAllAttached().Where(x => x.ScaleQuestionId > 10 && x.ScaleQuestionId < 14).ToListAsync();

    public async Task<List<YesNoQuestion>> GetFourthtPartOfSurvey() =>
    await yNQRepository.GetAllAttached().Where(x => x.YesNoQuestionId != 6).ToListAsync();

    public async Task<(MultipleChoiceQuestion mCQuestion, YesNoQuestion yNQuestion)> GetFifthPartOfSurvey()
    {
        var choices = cRepository.GetAllAttached().Include(x => x.MultipleChoiceQuestion).Where(x => x.MultipleChoiceQuestionId == 1);

        var question1 = choices.First().MultipleChoiceQuestion;

        foreach (var choice in choices)
        {
            question1.Choices.Add(choice);
        }

        var question2 = await yNQRepository.GetAllAttached().FirstAsync(x => x.YesNoQuestionId == 6);

        return (question1, question2);
    }
}