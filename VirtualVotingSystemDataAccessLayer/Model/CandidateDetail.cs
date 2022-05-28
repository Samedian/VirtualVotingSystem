using System;
using System.Collections.Generic;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class CandidateDetail
    {
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public long? AadharNumber { get; set; }
        public string CandidateParty { get; set; }
        public int Votes { get; set; }
        public string ConstituencyState { get; set; }

        public virtual UserDetail AadharNumberNavigation { get; set; }
    }
}
