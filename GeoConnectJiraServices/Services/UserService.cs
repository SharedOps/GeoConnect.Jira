using System;
using System.Collections.Generic;
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
                connection.StoredProcedure = Constants.InsertUsers;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add(Constants.FirstName_Param, user.FirstName);
                parameters.Add(Constants.LastName_Param, user.LastName);
                parameters.Add(Constants.Email_Param, user.Email);
                return _iJiraApplicationService.Execute(parameters, connection);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<IList<GetUser>> GetUsers()
        {
            connection.StoredProcedure = Constants.GetUsers;
            DynamicParameters parameters = new DynamicParameters();
            return _iJiraApplicationService.QueryList<GetUser>(parameters, connection);
        }
    }
}