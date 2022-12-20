using Microsoft.EntityFrameworkCore;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Clean.Domain;

namespace solidCleanarchitecture.Presistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly solidCleanarchitectureDbContext _dbContex;
    public LeaveRequestRepository(solidCleanarchitectureDbContext dbContext) : base(dbContext)
    {
        _dbContex = dbContext;
    }

    public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        _dbContex.Entry(leaveRequest).State = EntityState.Modified;
        await _dbContex.SaveChangesAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestListWithDetails()
    {
        var leaveRequest = await _dbContex.LeaveRequests
        .Include(q => q.LeaveType)
        .ToListAsync();
        return leaveRequest;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _dbContex.LeaveRequests
        .Include(q => q.LeaveType)
        .FirstOrDefaultAsync(q => q.Id == id);
        return leaveRequest;
    }
}
