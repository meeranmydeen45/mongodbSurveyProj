using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Survey.Api.Cloud.Core.Database.Mongo;
using System.Text.Json;

namespace Survey.Api.Cloud.Core.Service
{
    public class MongoService
    {
        private readonly IMongoCollection<SurveyModel> _surveyCollection;

        public MongoService(IOptions<MongoDBSettings> mongoDB)
        {
            var mongoClient = new MongoClient(mongoDB.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(mongoDB.Value.DatabaseName);

            _surveyCollection = mongoDatabase.GetCollection<SurveyModel>(mongoDB.Value.CollectionName);
        }

        public async Task<SurveyModel> GetSingleDocumentByCriteriaAsync(long vertexId, long projectId)
        {
            // ## Filter Defintion
            var filterBuilder = Builders<SurveyModel>.Filter;
            var vertexIdFilter = filterBuilder.Eq(x => x.VertexId, vertexId);
            var projectIdFilter = filterBuilder.Eq(x => x.ProjectId, projectId);
            var combineFilter = filterBuilder.And(vertexIdFilter, projectIdFilter);

            SurveyModel surveyModel = await _surveyCollection.Find(combineFilter).FirstOrDefaultAsync();

            return surveyModel ?? new SurveyModel();
        }

        public async Task<List<SurveyModel>> GetAllAsync()
        {

            return await _surveyCollection.Find(_ => true).ToListAsync();
        }

        public async Task<SurveyModel?> GetByIdAsync(long vertexId)
        {
            return await _surveyCollection.Find(x => x.VertexId == vertexId).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(SurveyModel surveyModel)
        {
            await _surveyCollection.InsertOneAsync(surveyModel);
        }


        public async Task UpdateAsync(long vertexId, SurveyModel updatedSurveyModel)
        {
            await _surveyCollection.ReplaceOneAsync(x => x.VertexId == vertexId, updatedSurveyModel);
        }


        public async Task RemoveAsync(long vertexId)
        {
            await _surveyCollection.DeleteOneAsync(x => x.VertexId == vertexId);
        }
    }
}
