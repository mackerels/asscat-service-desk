using System.Collections.Generic;
using SD.Models;
using SD.Models.Constants;

namespace SD.Models
{
    public class IssueModel
    {
        public int Id { get; set; }

        public string Topic{get; set;}

        public string Matter { get; set; }

        public CompanyModel Company { get; set; }

        public int CompanyId { get; set; }

        public AgentModel Owner { get; set; }

        public int OwnerId { get; set; }

        public AgentModel Responsible { get; set; }

        public int ResponsibleId { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IssueStatus Status { get; set; }

        public IEnumerable<IssueMessageModel> IssueMessages { get; set; }
    }
}