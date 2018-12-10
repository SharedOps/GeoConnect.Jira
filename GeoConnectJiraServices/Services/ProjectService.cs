using System;
using System.Threading.Tasks;
using GeoConnectJiraServices.Interfaces;
using GeoConnectJiraServices.Models;
using GeoConnect.Application.Interfaces;
using Dapper;
using GeoConnect.Application.Models;
using System.Configuration;
using GeoConnectJiraServices.Utilities;

namespace GeoConnectJiraServices.Services
{
    public class ProjectService : IProjectsService
    {
        private readonly IJiraApplicationService _iJiraApplicationService;

        private DBConnection connection { get; set; } = new DBConnection();

        public ProjectService(IJiraApplicationService jiraApplicationService)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["JIRAConnection"].ConnectionString;
            _iJiraApplicationService = jiraApplicationService;
        }

        public Task<int> AddProject(AddProject project)
        {
            try
            {
                connection.StoredProcedure = Constants.InsertProject;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.ProjectName_Param, project.ProjectName);
                return _iJiraApplicationService.Execute(parameters, connection);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}