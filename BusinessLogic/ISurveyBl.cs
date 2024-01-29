using Survey.Api.Cloud.Core.Request;
using Survey.Api.Cloud.Core.Response;

namespace Survey.Api.Cloud.Core.BusinessLogic
{
    public interface ISurveyBl
    {
        public Task<List<SurveyQuestionAnswerResponse>> GetSurveyQuestionAnswer(long vertexId, long projectId);
        public Task<string> CreateSurvey(CreateSurveyRequest createSurvey);
    }
}
