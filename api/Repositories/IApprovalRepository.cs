using api.Models;

namespace api.Repositories
{
    public interface IApprovalRepository
    {
        Task<ApprovalRequest?> GetById(int id);
        Task<List<ApprovalRequest>> GetAll();
        Task Add(ApprovalRequest approvalRequest);
        Task Update(ApprovalRequest approvalRequest);
        Task Delete(int id);
        Task SaveChanges();

    }
}
