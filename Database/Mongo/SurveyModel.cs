using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Dynamic;

namespace Survey.Api.Cloud.Core.Database.Mongo
{
    public class SurveyModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("vertexId")]
        public long VertexId { get; set; }

        [BsonElement("projectId")]
        public long ProjectId { get; set; }

        [BsonElement("anwers")]
        public List<SurveyAnswer> Answers { get; set; } = new();
    }
}