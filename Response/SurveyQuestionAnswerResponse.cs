using Survey.Api.Cloud.Core.DataBase.Entities;

namespace Survey.Api.Cloud.Core.Response
{
    public class SurveyQuestionAnswerResponse
    {
        public long QuestionId { get; set; }
        public string? Title { get; set; }
        public string? Formula { get; set; }
        public int InputTypeId { get; set; }
        public string? InputTypeName { get; set; }
        public List<Option>? Options { get; set; }
        public string? GroupName { get; set; }
        public bool IsMandatory { get; set; }
        public int? OrderSequence { get; set; }
        public double? AnswerNumeric { get; set; }
        public string? AnswerText { get; set; }
        public short[]? AnswerKeys { get; set; }
    }
}
