using System.Collections.Generic;
using SD.Models;

namespace SD.Storage
{
    public interface IServiceDeskStorage
    {
        IEnumerable<AgentModel> Agents { get; }

        IEnumerable<CompanyModel> Companies { get; }

        IEnumerable<IssueModel> Issues { get; }

        IEnumerable<IssueMessageModel> IssueMessages { get; }
    }
}