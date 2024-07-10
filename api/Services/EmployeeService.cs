using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Repositories;
using api.Enums;
using YourProject.Enums;

namespace api.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IProjectRepository projectRepository,
            IEmployeeProjectRepository employeeProjectRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _employeeProjectRepository = employeeProjectRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<List<LeaveRequest>> GetEmployeeLeaveRequestsAsync(int employeeId)
        {
            return await _leaveRequestRepository.GetByEmployeeId(employeeId);
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        public  Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee =  _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee with ID {id} not found.");
            }
            return employee;
        }

        public async Task<Employee> CreateEmploye(string FullName, Subdivision Subdivision,Position Position,
            EmployeeStatus EmployeeStatus, int peoplePartnerId, int OutOfOfficeBalance,
            string? photo)
        {

            Employee emp = new Employee
            {
                FullName = FullName,
                Subdivision = Subdivision,
                Position = Position,
                outOfOfficeBalance = OutOfOfficeBalance,
                Photo = photo,
                PeoplePartnerId = peoplePartnerId,
                Status = EmployeeStatus
            };

            return await _employeeRepository.AddAsync(emp);
        }
        public async Task<Employee> AddEmployeeToProject(int projectId, int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                throw new KeyNotFoundException("Employee with ID {id} not found.");

            var project = await _projectRepository.GetByIdAsync(projectId);
            if (project == null)
                throw new KeyNotFoundException("Project with ID {id} not found.");

            EmployeeProject entity = new()
            {
                Id = default,
                EmployeeId = employeeId,
                ProjectId = projectId,
            };

            var res = await _employeeProjectRepository.AddAsync(entity);
            employee = await _employeeRepository.GetByIdAsync(employeeId);
            return employee;
        }
    }
}
