using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
    public interface IResultDAL
    {
        Task<CandidateDetailEntity> GetCandidateWithHighestVotesByState(string state);
        Task<CandidateDetailEntity> GetCandidateWithLeastVotesByState(string state);
        Task<List<CandidateDetailEntity>> GetCandidatesByState(string state);
        Task<List<CandidateDetailEntity>> GetCandidates();

    }
}
