using System.Collections.Generic;
using Storage.Models;

namespace Storage
{
    public interface IServiceDeskStorage
    {
        IEnumerable<AgentModel> Agents { get; }

        IEnumerable<CompanyModel> Companies { get; }

        IEnumerable<IssueModel> Issues { get; }

        IEnumerable<IssueMessageModel> IssueMessages { get; }
    }
}