using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using  GeoConnect.Application.Models;


namespace GeoConnect.Application.Interfaces
{
   public interface IJiraApplicationService
   {

       Task<T> QueryOne<T>(DynamicParameters parameterModel, DBConnection connection) where T : new();

       Task<IList<T>> QueryList<T>(DynamicParameters parameterModel, DBConnection connection) where T : new();

       Task<int> Execute(DynamicParameters parameterModel, DBConnection connection);
    }
}
