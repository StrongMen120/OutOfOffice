using api.Enums;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using YourProject.Enums;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService projectService;

        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("/get/projects")]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
                var projects = await projectService.listAllProjects();
                return Ok(projects);
        }


        [HttpPost("create")]
        public async Task<ActionResult<Project>> createProject([FromBody] Project project)
        {
                    var Project = await projectService.createProject(project);
                    return Ok(Project);       
            
        }
    }
}
