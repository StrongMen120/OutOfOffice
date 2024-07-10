using api.Data;
using api.Enums;
using api.Models;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ProjectService
    {

        private readonly IProjectRepository _projectRepository;
        private readonly EmployeeService _employeeService;
        private readonly ApplicationDbContext _context;



        public ProjectService(IProjectRepository projectRepository, EmployeeService employeeService, ApplicationDbContext context)
        {
            _projectRepository = projectRepository;
            _employeeService = employeeService;
            _context = context;
        }

        public async Task<bool> addProjectToEmployee(int employeeId, int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
            {
                throw new ArgumentException("Project not Found");
            }
            var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);
            if (employee == null)
            {
                throw new ArgumentException("Employee not Found");
            }


            var newAssignment = new EmployeeProject
            {
                EmployeeId = employeeId,
                ProjectId = projectId
            };

            _context.EmployeeProjects.Add(newAssignment);
            await _projectRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> removeEmployeeFromProject(int projId, int empId)
        {
            var project = await _projectRepository.GetByIdAsync(projId);
            if (project == null)
            {
                throw new ArgumentException("Project not Found");
            }
            var employee = await _employeeService.GetEmployeeByIdAsync(empId);
            if (employee == null)
            {
                throw new ArgumentException("Employee not Found");
            }


            var newAssignment = new EmployeeProject
            {
                EmployeeId = empId,
                ProjectId = projId
            };

            _context.EmployeeProjects.Add(newAssignment);
            await _projectRepository.SaveChangesAsync();
            return true;
        }


        public async Task<Project> getProjectById(int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project != null)
            {
                return project;
            }
            throw new ArgumentException("Project not found!");
        }

        public async Task<List<Project>> listAllProjects()
        {
            var projList = await _projectRepository.GetAllAsync();
            return projList;
        }

        public async Task<Project> createProject(Project project)
        {
            Project project1 = new Project
            {
                ProjectType = project.ProjectType,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectManagerId = project.ProjectManagerId,
                Comment = project.Comment,
                Status = project.Status
            };

            return await _projectRepository.AddAsync(project1);
        }
    }

}
