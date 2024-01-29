namespace Survey.Api.Cloud.Core.DataBase.Entities
{
    public class Project
    {
        public Project()
        {
            Questions = new HashSet<Question>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set;}
    }
}
