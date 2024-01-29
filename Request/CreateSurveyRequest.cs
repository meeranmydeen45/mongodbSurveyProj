using Survey.Api.Cloud.Core.Database.Mongo;
using Survey.Api.Cloud.Core.Models;

namespace Survey.Api.Cloud.Core.Request
{
    public class CreateSurveyRequest 
    {
        public long ProjectId { get; set; }
        public long VertexId { get; set; }
        public List<QuestionRequest> Answers { get; set; } = new();

        public SurveyModel ToModel()
        {
            SurveyModel model = new SurveyModel();
            model.ProjectId = ProjectId;
            model.VertexId = VertexId;

            foreach (QuestionRequest answer in Answers)
            {
                SurveyAnswer surveyAnswer = answer.ToSurveyAnswer();
                model.Answers.Add(surveyAnswer);
            }
            return model;
        }

    }
}
