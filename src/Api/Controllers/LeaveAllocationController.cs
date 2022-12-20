using MediatR;
using Microsoft.AspNetCore.Mvc;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;
using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Commands;
using solidCleanarchitecture.Application.Features.LeaveAllocations.Requests.Queries;
namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<LeaveAllocationDto>>> Get()
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationListRequest());
        return Ok(leaveAllocation);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveAllocationDto>> Get([FromRoute] int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
        return Ok(leaveAllocation);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto leaveAllocation)
    {
        var response = await _mediator.Send(new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation });
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocation)
    {
        var respone = await _mediator.Send(new UpdateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocation });
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var respone = await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
        return NoContent();
    }
}
