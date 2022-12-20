using solidCleanarchitecture.Clean.Domain;

namespace solidCleanarchitecture.Application.Contracts.Persistence
{
    public interface IleaveAllocationRepository : IGenericRespository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationListWithDetails();
    }
}