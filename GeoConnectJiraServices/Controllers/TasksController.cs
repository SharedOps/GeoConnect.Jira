using System.Collections.Generic;
using GeoConnectJiraServices.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Controllers
{

    [RoutePrefix("sp/jira")]
    public class TasksController : ApiController
    {
        private readonly ITaskService _iTaskService;

        public TasksController(ITaskService iTaskService)
        {
            _iTaskService = iTaskService;
        }

        [HttpPost]
        [Route("addtask")]
        [ResponseType(typeof(Tasks))]
        public async Task<int> AddProject([FromBody] Tasks task)
        {
            return await _iTaskService.AddTasks(task);
        }
    }
}
