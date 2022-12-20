using solidCleanarchitecture.Clean.Domain;

namespace solidCleanarchitecture.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRespository<LeaveRequest>
    {

        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestListWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}