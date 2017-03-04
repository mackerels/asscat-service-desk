using System.Collections.Generic;
using System.Security.Claims;

namespace Storage.Models
{
    public class AgentModel : ClaimsIdentity
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