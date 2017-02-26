using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using service_desk.Models;
using SD.Models;
using SD.Storage;
using MySql.Data.MySqlClient;
using Dapper;

namespace service_desk.Storage
{
    public class DescStorage : IServiceDeskStorage
    {

        private MySqlConnection connection;

        public DescStorage()
        {
            connection = new MySqlConnection(@"Server=localhost;Port=3306;Database=2x2crm;Uid=root;Pwd=123;SslMode=None;"); 
            connection.Open();
        }

        public IEnumerable<AgentModel> Agents => connection.Query<AgentModel>("select Id, Name, CompanyId, Login, Password from agent");
        public IEnumerable<CompanyModel> Companies => connection.Query<CompanyModel>("select Id, Name from company");

        public IEnumerable<IssueModel> Issues
        { 
            get
            {
                const string sql = @"select issue.Id, Theme, Matter, Phone, Email, State, 
                       issue.CompanyId as Id, company.Name, 
                       OwnerId as Id, owner.Name, 
                       ResponsibleId as Id, resp.Name 
                    from issue 
                       left JOIN company on company.Id = issue.CompanyId 
                       left join agent owner on owner.Id = issue.OwnerId 
                       left join agent resp on resp.Id = issue.ResponsibleId";

                return connection.Query<IssueModel, CompanyModel, AgentModel, AgentModel, IssueModel>(sql,
                    (issue, company, owner, resp) =>
                    {
                        issue.Company = company;
                        issue.Owner = owner;
                        issue.Responsible = resp;
                        return issue;
                    });
            }
        }

        public IEnumerable<IssueMessageModel> IssueMessages
            =>
                connection.Query<IssueMessageModel>(
                    "select Id, IssueId, AgentId, MessageTime, Body from issue_message");
    }
}
