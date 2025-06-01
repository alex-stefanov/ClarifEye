using ClarifEye.Data.Enums;
using ClarifEye.Data.Models;
using ClarifEye.Data.Repository.Interfaces;
using ClarifEye.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Infrastructure.Implementations
{
    public class StatisticsService(
        IRepository<MultipleChoiceQuestion, int> mCQRepository,
        IRepository<ScaleQuestion, int> sQRepository,
        IRepository<YesNoQuestion, int> yNQRepository,
        IRepository<Choice, int> cRepository,
        IRepository<ChoiceAnswer, int> cARepository,
        IRepository<ScaleAnswer, int> sARepository,
        IRepository<YesNoAnswer, int> yNARepository
        ) : IStasticsService
    {

        public async Task<List<string>> GetAllQuestions()
        {
            var questions1 = await mCQRepository.GetAllAttached().Select(x => x.QuestionString).ToListAsync();
            var questions2 = await sQRepository.GetAllAttached().Select(x => x.QuestionText).ToListAsync();
            var questions3 = await yNQRepository.GetAllAttached().Select(x => x.QuestionText).ToListAsync();

            var questions = new List<string>();
            questions.AddRange(questions1);
            questions.AddRange(questions2);
            questions.AddRange(questions3);

            return questions;
        }
        public async Task<Dictionary<string, int>> FetchQuestionData(string question)
        {
            if (await mCQRepository.GetAllAttached().AnyAsync(x => x.QuestionString == question))
            {
                var questionEntity = await mCQRepository.GetAllAttached().FirstOrDefaultAsync(x => x.QuestionString == question);
                var choices = await cRepository.GetAllAttached().Where(x => x.MultipleChoiceQuestionId == questionEntity.MultipleChoiceQuestionId).ToListAsync();
                var choiceAnswers = await cARepository.GetAllAttached().Where(x => choices.Select(y => y.ChoiceId).ToList().Contains(x.ChoiceId)).ToListAsync();

                Dictionary<string, int> timesAnswered = new Dictionary<string, int>();

                foreach (var choice in choices)
                {
                    timesAnswered.Add(choice.AnswerString, 0);
                }

                foreach (var choiceAnswer in choiceAnswers)
                {
                    var choiceText = choices.First(x => x.ChoiceId == choiceAnswer.ChoiceId).AnswerString;
                    timesAnswered[choiceText]++;
                }

                return timesAnswered;
            }
            else if (await sQRepository.GetAllAttached().AnyAsync(x => x.QuestionText == question))
            {
                var questionEntity = await sQRepository.GetAllAttached().FirstOrDefaultAsync(x => x.QuestionText == question);
                List<ScaleEnum> scaleEnums = Enum.GetValues(typeof(ScaleEnum)).Cast<ScaleEnum>().ToList();
                var scaleAnswers = await sARepository.GetAllAttached().Where(x => scaleEnums.Contains(x.SelectedOption) && x.ScaleQuestionId == questionEntity.ScaleQuestionId).ToListAsync();
                Dictionary<string, int> timesAnswered = new Dictionary<string, int>();

                foreach (var scaleEnum in scaleEnums)
                {
                    timesAnswered.Add(scaleEnum.ToString(), 0);
                }
                foreach (var scaleAnswer in scaleAnswers)
                {
                    timesAnswered[scaleAnswer.SelectedOption.ToString()]++;
                }

                return timesAnswered;
            }
            else // YesNoQuestions
            {
                //Yes no is not returned correctly
                var questionEntity = yNQRepository.GetAllAttached().FirstOrDefault(x => x.QuestionText == question);
                List<YesNoEnum> yesNoEnums = Enum.GetValues(typeof(YesNoEnum)).Cast<YesNoEnum>().ToList();
                var yesNoAnswers = await yNARepository.GetAllAttached().Where(x => yesNoEnums.Contains(x.SelectedOption) && x.YesNoQuestionId == questionEntity.YesNoQuestionId).ToListAsync();
                Dictionary<string, int> timesAnswered = new Dictionary<string, int>();

                foreach (var yesNoEnum in yesNoEnums)
                {
                    timesAnswered.Add(yesNoEnum.ToString(), 0);
                }
                foreach (var yesNoAnswer in yesNoAnswers)
                {
                    timesAnswered[yesNoAnswer.SelectedOption.ToString()]++;
                }

                return timesAnswered;
            }
        }
    }
}
