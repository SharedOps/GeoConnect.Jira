using System;
using System.Threading.Tasks;
using GeoConnectJiraServices.Interfaces;
using GeoConnectJiraServices.Models;
using GeoConnect.Application.Interfaces;
using Dapper;
using GeoConnect.Application.Models;
using System.Configuration;

namespace GeoConnectJiraServices.Services
{
    public class TasksService: ITaskService
    {
        private readonly IJiraApplicationService _iJiraApplicationService;

        private DBConnection connection { get; set; } = new DBConnection();

        public TasksService(IJiraApplicationService jiraApplicationService)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["JIRAConnection"].ConnectionString;
            _iJiraApplicationService = jiraApplicationService;
        }


        public Task<int> AddTasks(Tasks task)
        {
            try
            {
                connection.StoredProcedure = "sp_Insert_Tasks";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_TaskName", task.TaskName);
                parameters.Add("@p_TaskDescription", task.TaskDescription);
                parameters.Add("@p_ProjectId", task.ProjectId);
                parameters.Add("@p_AssignedTo", task.AssignedTo);
                parameters.Add("@p_TaskStatus", task.TaskStatus);
                return _iJiraApplicationService.Execute(parameters, connection);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}