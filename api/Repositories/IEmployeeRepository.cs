using api.Models;

public interface IEmployeeRepository
{
    Task<Employee> GetByIdAsync(int id);
    Task<List<Employee>> GetAllAsync();
    Task<Employee> AddAsync(Employee employee);
    Task SaveChangesAsync();
}