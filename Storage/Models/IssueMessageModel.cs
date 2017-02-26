using System;

namespace Storage.Models
{
    public class IssueMessageModel
    {
        public int Id { get; set; }

        public int IssueId { get; set; }
        
        public IssueModel Issue { get; set; }

        public int AgentId { get; set; }

        public AgentModel Agent { get; set; }

        public DateTime MessageTime { get; set; }

        public string Body { get; set; }
        public AgentModel Commentator { get; set; }
    }
}