using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoConnect.Application.Interfaces;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;
using GeoConnect.Application.Models;

namespace GeoConnect.Application.Providers
{
    public class JiraApplicationService : IJiraApplicationService
    {
      
        public Task<IList<T>> QueryList<T>(DynamicParameters parameterModel, DBConnection connection) where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                IList<T> results = con.Query<T>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).ToList();
                return Task.FromResult(results);
            }
        }


        public Task<T> QueryOne<T>(DynamicParameters parameterModel, DBConnection connection) where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                return Task.FromResult(con.Query<T>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).FirstOrDefault());
            }
        }


        public Task<int> Execute(DynamicParameters parameterModel, DBConnection connection) //where T : new()
        {
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                con.Open();
                return Task.FromResult(con.Query<int>(connection.StoredProcedure, parameterModel, null, true, null, CommandType.StoredProcedure).SingleOrDefault());

            }
        }
    }
}
