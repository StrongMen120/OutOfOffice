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


        public EmployeeService(
            IEmployeeRepository employeeRepository,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _employeeRepository = employeeRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<HashSet<EmployeeProject>> GetEmployeeProjectsAsync(int employeeId)
        {
            var employee = await GetEmployeeByIdAsync(employeeId);
            return employee.EmployeeProjects.ToHashSet();
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

        public async Task<Employee> createEmploye(string FullName, Subdivision Subdivision,Position Position,
            EmployeeStatus EmployeeStatus, int peoplePartnerId, int OutOfOfficeBalance,
            string photo)
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



    }
}
