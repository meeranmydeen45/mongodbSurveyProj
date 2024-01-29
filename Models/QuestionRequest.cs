using Survey.Api.Cloud.Core.Database.Mongo;
using Survey.Api.Cloud.Core.Enum;

namespace Survey.Api.Cloud.Core.Models
{
    public class QuestionRequest
    {
        public int QuestionId { get; set; }
        public short InputTypeId { get; set; }
        public double? AnswerNumeric { get; set; }
        public string? AnswerText { get; set; }
        public short[]? AnswerKeys { get; set; }

        public SurveyAnswer ToSurveyAnswer()
        {
            SurveyAnswer surveyAnswer = new SurveyAnswer();
            surveyAnswer.QuestionId = QuestionId;
            surveyAnswer.InputTypeId = InputTypeId;

            switch ((InputTypes)InputTypeId)
            {
                case InputTypes.TextArea:
                case InputTypes.TextField:
                case InputTypes.Date:
                case InputTypes.Attachment:
                    surveyAnswer.Answer = (string?)AnswerText;
                    break;
                case InputTypes.Numeric:
                case InputTypes.Radio:
                case InputTypes.Dropdown:
                case InputTypes.ToggleDigital:
                case InputTypes.Autocomplete:
                    surveyAnswer.Answer = (double?)AnswerNumeric;
                    break;
                case InputTypes.MultiSelectCheckbox:
                case InputTypes.MultiSelectDropdown:
                case InputTypes.Checkbox:
                    surveyAnswer.Answer = (short[]?)AnswerKeys;
                    break;
                default:
                    surveyAnswer.Answer = null;
                    break;
            }
            return surveyAnswer;
        }
    }
}
