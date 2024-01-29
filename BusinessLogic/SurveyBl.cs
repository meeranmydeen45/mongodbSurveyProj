using Survey.Api.Cloud.Core.BusinessRepository;
using Survey.Api.Cloud.Core.Request;
using Survey.Api.Cloud.Core.Response;

namespace Survey.Api.Cloud.Core.BusinessLogic
{
    public class SurveyBl : ISurveyBl
    {
        private readonly ISurveyBr surveyBr;

        public SurveyBl(ISurveyBr mSurveyBr)
        {
            surveyBr = mSurveyBr;
        }

        public Task<string> CreateSurvey(CreateSurveyRequest createSurvey)
        {
            return surveyBr.CreateSurvey(createSurvey);
        }

        public Task<List<SurveyQuestionAnswerResponse>> GetSurveyQuestionAnswer(long vertexId, long projectId)
        {
            return surveyBr.GetSurveyQuestionAnswer(vertexId, projectId);
        }
    }
}
