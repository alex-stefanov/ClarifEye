using ClarifEye.Data.Enums;
using ClarifEye.Data.Models;

public class SurveyViewModel
{
    // Existing presentation parts
    public List<ScaleQuestion> FirstPart { get; set; }
    public List<ScaleQuestion> SecondPart { get; set; }
    public List<ScaleQuestion> ThirdPart { get; set; }
    public List<YesNoQuestion> FourthPart { get; set; }
    public (MultipleChoiceQuestion, YesNoQuestion) FifthPart { get; set; }

    // Answer inputs
    public List<ScaleAnswerInput> ScaleAnswers { get; set; } = new ();
    public List<YesNoAnswerInput> YesNoAnswers { get; set; } = new();
    public List<int> ChoiceAnswerIds { get; set; } = new();
}

public class ScaleAnswerInput
{
    public int QuestionId { get; set; }
    public ScaleEnum Answer { get; set; }
}

public class YesNoAnswerInput
{
    public int QuestionId { get; set; }
    public YesNoEnum Answer { get; set; }
}
