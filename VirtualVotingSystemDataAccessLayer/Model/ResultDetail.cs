using System;
using System.Collections.Generic;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class ResultDetail
    {
        public string ConstituencyState { get; set; }
        public DateTime DateofElection { get; set; }
        public string PartyOpted { get; set; }
        public string CandidateId { get; set; }

        public virtual CandidateDetail Candidate { get; set; }
    }
}
