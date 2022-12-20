using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCleanarchitecture.Clean.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}