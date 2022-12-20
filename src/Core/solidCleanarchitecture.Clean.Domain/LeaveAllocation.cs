using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using solidCleanarchitecture.Clean.Domain.Common;

namespace solidCleanarchitecture.Clean.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

    }
}