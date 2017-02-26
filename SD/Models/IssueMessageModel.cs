using SD.Models.Constants;

namespace SD.Models
{
    public class IssueMessageModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public AgentModel Commentator { get; set; }
    }
}