using Newtonsoft.Json;
using Survey.Api.Cloud.Core.Enum;
using Survey.Api.Cloud.Core.Models;
using System.Text.Json.Nodes;

namespace Survey.Api.Cloud.Core.Database.Mongo
{
    public class SurveyAnswer : DataCreationInfo
    {
        public long QuestionId { get; set; }
        public short InputTypeId { get; set; }
        public object? Answer { get; set; }
    }
}
