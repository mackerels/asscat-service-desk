﻿using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using Storage.Models;

namespace Storage
{
    public class DescStorage : IServiceDeskStorage
    {

        private readonly MySqlConnection _connection;

        public DescStorage(string connectionString)
        {
            _connection =
                new MySqlConnection(connectionString);
            _connection.Open();
        }

        public IEnumerable<AgentModel> Agents
        {
            get
            {
                const string sql = @"select agent.Id, agent.Name, Login, Password, company.Id, company.Name
                                    from agent
                                    left join company on company.Id = CompanyId";

                return _connection.Query<AgentModel, CompanyModel, AgentModel>(sql, (agent, company) =>
                    {
                        agent.Company = company;
                        return agent;
                    }
                );
            }
        }

        public IEnumerable<CompanyModel> Companies => _connection.Query<CompanyModel>("select Id, Name from company");

        public IEnumerable<IssueModel> Issues
        {
            get
            {
                const string sql = @"select issue.Id, Topic, Matter, Phone, Email, State,
                       issue.CompanyId as Id, company.Name,
                       OwnerId as Id, owner.Name,
                       companyOwner.Id, companyOwner.Name,
                       ResponsibleId as Id, resp.Name,
                       companyResp.Id, companyResp.Name
                       from issue
                              left JOIN company on company.Id = issue.CompanyId
                              left join agent owner on owner.Id = issue.OwnerId
                              left join company as companyOwner on companyOwner.Id = owner.CompanyId
                              left join agent resp on resp.Id = issue.ResponsibleId
                              left join company as companyResp on companyResp.Id = resp.CompanyId";

                return _connection.Query<IssueModel, CompanyModel, AgentModel, CompanyModel, AgentModel, CompanyModel, IssueModel>(sql,
                    (issue, company, owner, ownerCompany, resp, respCompany) =>
                    {
                        issue.Company = company;
                        issue.Owner = owner;
                        owner.Company = ownerCompany;
                        issue.Responsible = resp;
                        resp.Company = respCompany;
                        return issue;
                    });
            }
        }

        public IEnumerable<IssueMessageModel> IssueMessages
        {
            get
            {
                const string sql = @"select  issue_message.Id, MessageTime, Body,
                                            issue.Id, issue.Email, issue.Matter, issue.Phone, issue.State, issue.Topic,
                                            issueCompany.Id, issueCompany.Name,
                                            issueOwner.Id, issueOwner.Name,
                                            resp.Id, resp.Name,
                                            messageAgent.Id, messageAgent.Name
                                    from issue_message
                                            left join issue on issue.Id = issue_message.IssueId
                                            left join company issueCompany on issueCompany.Id = issue.CompanyId
                                            left join agent issueOwner on issueOwner.Id = issue.OwnerId
                                            left join agent resp on resp.Id = issue.ResponsibleId
                                            left join agent messageAgent on messageAgent.Id = issue_message.AgentId";

                return _connection.Query<IssueMessageModel, IssueModel, CompanyModel, AgentModel, AgentModel, AgentModel, IssueMessageModel>(sql,
                        (message, issue, company, owner, resp, messAgent) =>
                        {
                            issue.Company = company;
                            issue.Owner = owner;
                            issue.Responsible = resp;
                            message.Issue = issue;
                            message.Agent = messAgent;
                            return message;
                        });

            }
        }
    }
}
