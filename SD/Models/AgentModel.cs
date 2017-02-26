using System.Collections;
using System.Collections.Generic;
using SD.Models;
using SD.Models.Constants;

namespace SD.Models
{
    public class AgentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CompanyModel Company { get; set; }

        public int CompanyId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public IEnumerable<IssueModel> Issues { get; set; }
    }
}