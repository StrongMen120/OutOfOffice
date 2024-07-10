using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/approval-request")]
    public class ApprovalRequestController : ControllerBase
    {

        private readonly ApprovalRequestService _approvalRequestService;

        public ApprovalRequestController(ApprovalRequestService approvalRequestService)
        {
            _approvalRequestService = approvalRequestService;
        }


        [HttpGet("get")]
        public async Task<List<ApprovalRequest>> GetApproval() 
        {
            return await _approvalRequestService.getAllApprovalRequests();
        }

    }
}
