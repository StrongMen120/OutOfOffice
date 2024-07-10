using api.Data;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class ApprovalRequestService
    {
        private readonly IApprovalRepository _approvalRepository;

        public ApprovalRequestService(IApprovalRepository approvalRepository)
        {
            _approvalRepository = approvalRepository;
        }


        public async Task<ApprovalRequest> addAproval(ApprovalRequest approvalRequest)
        {
            if(approvalRequest == null)
            {
                throw new InvalidDataException("Provided Approval is null");
            }

            await _approvalRepository.Add(approvalRequest);
            return approvalRequest;
        }

        public async Task<List<ApprovalRequest>> getAllApprovalRequests()
        {
            return await _approvalRepository.GetAll();
        }




    }
}
