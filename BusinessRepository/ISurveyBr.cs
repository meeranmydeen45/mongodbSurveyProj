using Survey.Api.Cloud.Core.Request;
using Survey.Api.Cloud.Core.Response;

namespace Survey.Api.Cloud.Core.BusinessRepository
{
    public interface ISurveyBr
    {
        public Task<List<SurveyQuestionAnswerResponse>> GetSurveyQuestionAnswer(long vertexId, long projectId);

        public Task<string> CreateSurvey(CreateSurveyRequest createSurvey);
    }
}
