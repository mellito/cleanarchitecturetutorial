using AutoMapper;
using solidCleanarchitecture.Clean.Domain;
using solidCleanarchitecture.Application.Dtos.LeaveAllocation;
using solidCleanarchitecture.Application.Dtos.LeaveType;
using solidCleanarchitecture.Application.Dtos.LeaveRequest;

namespace solidCleanarchitecture.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            #endregion

            #region LeaveType
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            #endregion

            #region LeaveAllocation
            CreateMap<LeaveAllocationDto, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationDto, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocationDto, UpdateLeaveAllocationDto>().ReverseMap();
            #endregion
        }
    }
}