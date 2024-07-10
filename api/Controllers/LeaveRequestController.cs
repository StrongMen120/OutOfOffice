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

        [HttpGet("leave-requests")]
        public Task<List<LeaveRequest>> GetAllRequests()
        {
            return _leaveRequestService.getAllLeaveRequests();
        }

        [HttpPost("leave-request")]
        public async Task<ActionResult<LeaveRequest>> CreateLeaveRequest([FromBody] LeaveRequest request)
        {
            var leaveRequest = await _leaveRequestService.createLeaveRequest(request);
            return Ok(leaveRequest);
        }

        [HttpPut("leave-requests/submit")]
        public async Task<ActionResult<LeaveRequest>> SubbmitLeaveRequest(int requestId, int approverId)
        {
            var leaveRequest = await _leaveRequestService.subbmitRequest(requestId, approverId);
            return Ok(leaveRequest);
    }

    }
}
