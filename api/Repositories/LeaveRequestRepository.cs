using api.Data;
using api.Enums;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeaveRequest?> GetById(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<List<LeaveRequest>> GetByEmployeeId(int employeeId)
        {
            return await _context.LeaveRequests
                .Where(lr => lr.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetAll()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task Add(LeaveRequest leaveRequest)
        {
            await _context.LeaveRequests.AddAsync(leaveRequest);
        }

        public async Task Update(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
        }

        public async Task Delete(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
