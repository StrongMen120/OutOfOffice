using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ApprovalRepository : IApprovalRepository
    {
        private readonly ApplicationDbContext _context;

        public ApprovalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApprovalRequest?> GetById(int id)
        {
            return await _context.ApprovalRequests.FindAsync(id);
        }

        public async Task<List<ApprovalRequest>> GetAll()
        {
            return await _context.ApprovalRequests.ToListAsync();
        }

        public async Task Add(ApprovalRequest approvalRequest)
        {
            await _context.ApprovalRequests.AddAsync(approvalRequest); 
        }

        public async Task Update(ApprovalRequest approvalRequest)
        {
            _context.ApprovalRequests.Update(approvalRequest);
        }

        public async Task Delete(int id)
        {
            var approvalRequest = await _context.ApprovalRequests.FindAsync(id);
            if(approvalRequest != null)
            {
                _context.ApprovalRequests.Remove(approvalRequest); ;
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
