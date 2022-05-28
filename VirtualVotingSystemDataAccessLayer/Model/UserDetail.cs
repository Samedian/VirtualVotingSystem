using System;
using System.Collections.Generic;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class UserDetail
    {
        public UserDetail()
        {
            CandidateDetails = new HashSet<CandidateDetail>();
        }

        public long AadharNumber { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long MobileNumber { get; set; }
        public long? AddressId { get; set; }

        public virtual AddressDetail Address { get; set; }
        public virtual UserId UserId { get; set; }
        public virtual ICollection<CandidateDetail> CandidateDetails { get; set; }
    }
}
