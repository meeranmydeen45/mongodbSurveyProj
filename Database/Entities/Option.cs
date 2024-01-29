namespace Survey.Api.Cloud.Core.DataBase.Entities
{
    public class Option
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public int Key { get; set; }
        public long QuestionId { get; set; }

        public Question QuestionNavigation { get; set; }
    }
}
