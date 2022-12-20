using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solidCleanarchitecture.Clean.Domain.Common;
namespace solidCleanarchitecture.Clean.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime? DateRquested { get; set; }
        public string? RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}