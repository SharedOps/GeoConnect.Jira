using System.Threading.Tasks;
using GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Interfaces
{
    public interface ITaskService
    {
        Task<int> AddTasks(Tasks task);
    }
}
