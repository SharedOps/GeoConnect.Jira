using System.Collections.Generic;
using GeoConnectJiraServices.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GeoConnectJiraServices.Models;

namespace GeoConnectJiraServices.Controllers
{
    [RoutePrefix("sp/jira")]
    public class ProjectsController : ApiController
    {
        private readonly IProjectsService _iProjectService;

        public ProjectsController(IProjectsService iProjectService)
        {
            _iProjectService = iProjectService;
        }

        [HttpPost]
        [Route("addproject")]
        [ResponseType(typeof(AddProject))]
        public async Task<int> AddProject([FromBody] AddProject project)
        {
            return await _iProjectService.AddProject(project);
        }
    }
}
