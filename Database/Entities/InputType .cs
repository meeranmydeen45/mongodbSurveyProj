namespace Survey.Api.Cloud.Core.DataBase.Entities
{
    public class InputType
    {
        public InputType()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
