using Microsoft.EntityFrameworkCore;
using Survey.Api.Cloud.Core.Database.Mongo;
using Survey.Api.Cloud.Core.DataBase.DBContext;
using Survey.Api.Cloud.Core.DataBase.Entities;
using Survey.Api.Cloud.Core.Enum;
using Survey.Api.Cloud.Core.Request;
using Survey.Api.Cloud.Core.Response;
using Survey.Api.Cloud.Core.Service;

namespace Survey.Api.Cloud.Core.BusinessRepository
{
    public class SurveyBr : ISurveyBr
    {
        private readonly SurveyDBContext dbContext;
        private readonly MongoService mongoService;
        private readonly ILogger<SurveyBr> logger;
        public SurveyBr(SurveyDBContext _dbContext, MongoService _mongoService, ILogger<SurveyBr> _logger)
        {
            dbContext = _dbContext;
            mongoService = _mongoService;
            logger = _logger;
        }

        public async Task<string> CreateSurvey(CreateSurveyRequest createSurvey)
        {
            SurveyModel document = createSurvey.ToModel();

            if (createSurvey.VertexId > 0 && createSurvey.ProjectId > 0)
            {
                await mongoService.CreateAsync(document);
            }
            else
            {
               throw new InvalidDataException($" VertexId and ProjectId must greater than 0");
            }

            return $"Survey Created with Id {document.Id}";
        }

        public async Task<List<SurveyQuestionAnswerResponse>> GetSurveyQuestionAnswer(long vertexId, long projectId)
        {
            List<SurveyQuestionAnswerResponse> response = new ();
            Dictionary<long, object?> dicAnswer = new();

            SurveyModel surveyModel = await mongoService.GetSingleDocumentByCriteriaAsync(vertexId, projectId);
            
            List<Question> questions = await dbContext.Questoins
                                                .Where(x => x.ProjectId == projectId)
                                                .Include(x => x.InputTypeNavigation)
                                                .Include(opt => opt.Options)
                                                .Include(g => g.GroupNavigation)
                                                .ToListAsync();

            dicAnswer = surveyModel.Answers?.Count > 0 
                            ? surveyModel.Answers.ToDictionary(x => x.QuestionId, x => x.Answer)
                            : dicAnswer;

            questions.ForEach(q =>
            {
                _ = dicAnswer.TryGetValue(q.Id, out object? answer);

                var surveyAnswer = new SurveyQuestionAnswerResponse
                {
                    QuestionId = q.Id,
                    Title = q.Title,
                    Formula = q.Formula,
                    InputTypeId= q.InputTypeId,
                    InputTypeName = q.InputTypeNavigation.Name,
                    IsMandatory = q.IsMandatory,
                    GroupName = q.GroupNavigation?.Name,
                    OrderSequence = q.OrderSequence,
                    Options = q.Options?
                               .Select(x => new Option
                               {
                                  Id = x.Id,
                                  Key = x.Key,
                                  Value = x.Value,
                               }).ToList(),
                };

                SetAnswerBasedOnInputType(surveyAnswer, surveyAnswer.InputTypeId, answer);
                response.Add(surveyAnswer);
            });
            return response;
        }

        private void SetAnswerBasedOnInputType(SurveyQuestionAnswerResponse surveyAnswer, int inputTypeId, object? answer)
        {
            switch((InputTypes)inputTypeId)
            {
                case InputTypes.TextArea:
                case InputTypes.TextField:
                case InputTypes.Date:
                case InputTypes.Attachment:
                    surveyAnswer.AnswerText = (string?)answer;
                    break;
                case InputTypes.Numeric:
                case InputTypes.Radio:
                case InputTypes.Dropdown:
                case InputTypes.ToggleDigital:
                case InputTypes.Autocomplete:
                    surveyAnswer.AnswerNumeric = (double?)answer;
                    break;
                case InputTypes.MultiSelectCheckbox:
                case InputTypes.MultiSelectDropdown:
                case InputTypes.Checkbox:
                    surveyAnswer.AnswerKeys = (short[]?)answer;
                    break;
            }
        }
    }
}
