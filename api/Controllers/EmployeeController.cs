using api.dto;
using api.Enums;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using YourProject.Enums;

namespace api.Controllers
    
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeService;


        public EmployeeController(EmployeeService employeService)
        {
            _employeService = employeService;
        }

        [HttpGet("/get/employees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employess = await _employeService.GetAllEmployeesAsync();

            return Ok(employess);
        }
        [HttpGet("/get/proj/{id}")]
        public async Task<ActionResult<ISet<Project>>> GetEmployeeProjects(int id)
        {
            try
            {
                var projects = await _employeService.GetEmployeeProjectsAsync(id);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/get/{id}")]
        public async Task<ActionResult<List<Employee>>> getEmplyeeById(int id)
        {
            try
            {
                var employee = await _employeService.GetEmployeeByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<Employee>> createEmployee(
             string FullName,  Subdivision Subdivision,  Position Position,
            EmployeeStatus EmployeeStatus,  int peoplePartnerId, int OutOfOfficeBalance,
            string? photo)
        {
            try
            {
                var Employee = await _employeService.createEmploye(FullName,Subdivision,Position,
                    EmployeeStatus,peoplePartnerId,OutOfOfficeBalance,photo);
                return Ok(Employee);

            }
            catch (Exception ex)
            {
                throw new Exception("Bad Request");
            }
        }
    }



    
}
