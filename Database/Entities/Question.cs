using System.ComponentModel.DataAnnotations;

namespace Survey.Api.Cloud.Core.DataBase.Entities
{
    public class Question
    {
        public Question()
        {

            Options = new HashSet<Option>();
        }

        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public int InputTypeId { get; set; }
        public bool IsMandatory { get; set; }
        public string Formula { get; set; }
        public long? QuestionGroupId { get; set; }
        public long ProjectId { get; set; }
        public int? OrderSequence { get; set; }

        public InputType InputTypeNavigation { get; set; }
        public Group? GroupNavigation { get; set; }
        public Project ProjectNavigation { get; set; }

        public virtual ICollection<Option> Options { get; set;}
    }
}
