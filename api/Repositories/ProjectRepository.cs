
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.EmployeeProjects)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.EmployeeProjects)
                .ToListAsync();
        }

        public async Task<Project> AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Projects
                .Where(p => p.EmployeeProjects.Any(e => e.EmployeeId == employeeId))
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
