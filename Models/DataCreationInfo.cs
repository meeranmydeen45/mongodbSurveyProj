namespace Survey.Api.Cloud.Core.Models
{
    public class DataCreationInfo
    {
        public long CreatedBy { get; set; } = 1;
        public long ModifiedBy { get; set; } = 1;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime ModifiedDateTime { get; set;} = DateTime.Now;
    }
}
