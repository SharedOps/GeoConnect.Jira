using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeoConnectJiraServices.Interfaces;
using GeoConnectJiraServices.Models;
using GeoConnect.Application.Interfaces;
using Dapper;
using GeoConnect.Application.Models;
using System.Configuration;

namespace GeoConnectJiraServices.Services
{
    public class UserService : IUser
    {
        private readonly IJiraApplicationService _iJiraApplicationService;

        private DBConnection connection { get; set; } = new DBConnection();

        public UserService(IJiraApplicationService jiraApplicationService)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["JIRAConnection"].ConnectionString;
            _iJiraApplicationService = jiraApplicationService;
        }

        public Task<int> AddUser(AddUser user)
        {
            try
            {
                connection.StoredProcedure = "sp_Insert_Users";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@p_Firstname", user.FirstName);
                parameters.Add("@p_Lastname", user.LastName);
                parameters.Add("@p_Email", user.Email);
                return _iJiraApplicationService.Execute(parameters, connection);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<IList<AddUser>> GetUsers()
        {
            connection.StoredProcedure = "sp_Insert_Users";
            DynamicParameters parameters = new DynamicParameters();
            return _iJiraApplicationService.QueryList<AddUser>(parameters, connection);
        }
    }
}