using System.Collections.Generic;
using System.Threading.Tasks;
using GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Interfaces
{
    public interface IUser
    {
        Task<int> AddUser(AddUser user);


        Task<IList<AddUser>> GetUsers();
    }
}
