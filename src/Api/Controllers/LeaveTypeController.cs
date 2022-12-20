using MediatR;
using Microsoft.AspNetCore.Mvc;
using solidCleanarchitecture.Application.Dtos.LeaveType;
using solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Commands;
using solidCleanarchitecture.Application.Features.LeaveTypes.Requests.Queries;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> Get()
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());
        return Ok(leaveType);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> Get([FromRoute] int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
        return Ok(leaveType);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveTypeDto leaveType)
    {
        var response = await _mediator.Send(new CreateLeaveTypeCommand { CreateLeaveTypeDto = leaveType });
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] LeaveTypeDto leaveType)
    {
        var respone = await _mediator.Send(new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var respone = await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
        return NoContent();
    }
}
