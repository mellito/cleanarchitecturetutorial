
using Microsoft.EntityFrameworkCore;
using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Clean.Domain;

namespace solidCleanarchitecture.Presistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, IleaveAllocationRepository
{
    private readonly solidCleanarchitectureDbContext _dbContex;
    public LeaveAllocationRepository(solidCleanarchitectureDbContext dbContext) : base(dbContext)
    {
        _dbContex = dbContext;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails()
    {
        var LeaveAllocation = await _dbContex.LeaveAllocations
        .Include(q => q.LeaveType)
        .ToListAsync();
        return LeaveAllocation;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var LeaveAllocation = await _dbContex.LeaveAllocations
        .Include(q => q.LeaveType)
        .FirstOrDefaultAsync(q => q.Id == id);
        return LeaveAllocation;
    }
}
