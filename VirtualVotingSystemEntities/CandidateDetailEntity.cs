using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualVotingSystemEntities
{
    public class CandidateDetailEntity
    {
        
        public string CandidateId { get; set; }
        public string CandidateName { get; set; }
        public long AadharNumber { get; set; }
        public string CandidateParty { get; set; }
        public int Votes { get; set; }
        public string ConstituencyState { get; set; }
    }
}
