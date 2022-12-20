using MediatR;
using Microsoft.AspNetCore.Mvc;
using solidCleanarchitecture.Application.Dtos.LeaveRequest;
using solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Commands;
using solidCleanarchitecture.Application.Features.LeaveRequests.Requests.Queries;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<LeaveRequestDto>>> Get()
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestListRequest());
        return Ok(leaveRequest);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveRequestDto>> Get([FromRoute] int id)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
        return Ok(leaveRequest);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto leaveRequest)
    {
        var response = await _mediator.Send(new CreateLeaveRequestCommand { LeaveRequestDto = leaveRequest });
        return Ok(response);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveRequestDto leaveRequest, [FromRoute] int id)
    {
        var respone = await _mediator.Send(new UpdateLeaveRequestCommand { Id = id, LeaveRequestsDto = leaveRequest });
        return NoContent();
    }
    [HttpPut("changeapproval/{id}")]
    public async Task<ActionResult> Put([FromBody] ChangeLeaveRequestApprovalDto status, [FromRoute] int id)
    {
        var respone = await _mediator.Send(new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDto = status });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var respone = await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
        return NoContent();
    }
}
