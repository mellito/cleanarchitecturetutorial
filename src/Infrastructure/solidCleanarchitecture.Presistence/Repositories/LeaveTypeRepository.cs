

using solidCleanarchitecture.Application.Contracts.Persistence;
using solidCleanarchitecture.Clean.Domain;

namespace solidCleanarchitecture.Presistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly solidCleanarchitectureDbContext _dbContext;
    public LeaveTypeRepository(solidCleanarchitectureDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
