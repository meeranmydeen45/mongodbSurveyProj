using Microsoft.AspNetCore.Mvc;
using Survey.Api.Cloud.Core.BusinessLogic;
using Survey.Api.Cloud.Core.Database.Mongo;
using Survey.Api.Cloud.Core.Request;
using Survey.Api.Cloud.Core.Service;

namespace Survey.Api.Cloud.Core.Controllers
{
    [ApiController]
    [Route("api/v1/survey")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyBl surveyBl;

        public SurveyController(ISurveyBl mSurveyBl)
        {
            surveyBl = mSurveyBl;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyRequest createSurvey)
        {
            return Created(string.Empty, await surveyBl.CreateSurvey(createSurvey));
        }


        [HttpGet("{vertexId}/{projectId}")]
        public async Task<IActionResult> GetSurveyQuestionAnswer(long vertexId, long projectId)
        {
            var res = await surveyBl.GetSurveyQuestionAnswer(vertexId, projectId);
            return res is not null ? Ok(res) : NoContent();
        }
    }
}