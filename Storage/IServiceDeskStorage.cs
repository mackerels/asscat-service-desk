using System.Collections.Generic;
using Storage.Models;

namespace Storage
{
    public interface IServiceDeskStorage
    {
        IEnumerable<AgentModel> Agents { get; }

        AgentModel AddOrUpdateAgent(AgentModel agent);

        AgentModel DeleteAgent(AgentModel agent);

        AgentModel FindByIdAsync(int id);

        IEnumerable<CompanyModel> Companies { get; }

        IEnumerable<IssueModel> Issues { get; }

        IEnumerable<IssueMessageModel> IssueMessages { get; }
    }
}