using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {

        private readonly LeaveRequestService _leaveRequestService;


        public LeaveRequestController(LeaveRequestService leaveRequest)
        {
            _leaveRequestService = leaveRequest;
        }

        [HttpGet("get/leaverequest")]
        public Task<List<LeaveRequest>> getAllRequests()
        {
            return _leaveRequestService.getAllLeaveRequests();
        }

        [HttpPost("create")]
        public async Task<ActionResult<LeaveRequest>> createLeaveRequest([FromBody] LeaveRequest request)
        {
            var leaveRequest = await _leaveRequestService.createLeaveRequest(request);
            return Ok(leaveRequest);
        }

        [HttpPut("/submit")]
        public async Task<ActionResult<LeaveRequest>> subbmitLeaveRequest(int requestId, int approverId)
        {
            var leaveRequest = await _leaveRequestService.subbmitRequest(requestId, approverId);
            return Ok(leaveRequest);
    }

    }
}
