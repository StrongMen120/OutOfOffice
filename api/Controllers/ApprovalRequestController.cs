using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApprovalRequestController : ControllerBase
    {

        private readonly ApprovalRequestService _approvalRequestService;

        public ApprovalRequestController(ApprovalRequestService approvalRequestService)
        {
            _approvalRequestService = approvalRequestService;
        }


        [HttpGet("approval-request")]
        public async Task<List<ApprovalRequest>> GetApproval() 
        {
            return await _approvalRequestService.getAllApprovalRequests();
        }

    }
}
