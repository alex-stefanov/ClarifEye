using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClarifEye.Infrastructure.Interfaces
{
    public interface IStasticsService
    {
        public Task<List<string>> GetAllQuestions();
        public Task<Dictionary<string, int>> FetchQuestionData(string question);
    }
}
