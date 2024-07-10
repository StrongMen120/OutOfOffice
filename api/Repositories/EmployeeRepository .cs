using api.Models;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EmployeeRepository  : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.EmployeeProjects)
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    
    } 
}
