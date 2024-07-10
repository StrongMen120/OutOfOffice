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

        [HttpGet("employees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employess = await _employeService.GetAllEmployeesAsync();

            return Ok(employess);
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmplyeeById(int employeId)
        {
            try
            {
                var employee = await _employeService.GetEmployeeByIdAsync(employeId);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("employee")]
        public async Task<ActionResult<Employee>> CreateEmployee(
             string FullName,  Subdivision Subdivision,  Position Position,
            EmployeeStatus EmployeeStatus,  int peoplePartnerId, int OutOfOfficeBalance,
            string? photo)
        {
            try
            {
                var Employee = await _employeService.CreateEmploye(FullName, Subdivision, Position,
                    EmployeeStatus, peoplePartnerId, OutOfOfficeBalance, photo);
                return Ok(Employee);

            }
            catch (Exception ex)
            {
                throw new Exception("Bad Request");
            }
        }


        [HttpPut("add-employee-to-project")]
        public async Task<ActionResult<Employee>> AddEmployeeToProject(int projectId, int employeId)
        {
            try
            {
                var Employee = await _employeService.AddEmployeeToProject(projectId, employeId);
                return Ok(Employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Bad Request");
            }
        }
    }



    
}
