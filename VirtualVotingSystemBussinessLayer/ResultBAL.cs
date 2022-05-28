using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public class ResultBAL : IResultBAL
    {
        private IResultDAL _resultDAL;
        public ResultBAL(IResultDAL resultDAL)
        {
            _resultDAL = resultDAL;
        }
        public async Task<List<CandidateDetailEntity>> GetCandidates()
        {
            return await _resultDAL.GetCandidates();
        }

        public async  Task<List<CandidateDetailEntity>> GetCandidatesByState(string state)
        {
            return await _resultDAL.GetCandidatesByState(state);
        }

        public async Task<CandidateDetailEntity> GetCandidateWithHighestVotesByState(string state)
        {
            return await  _resultDAL.GetCandidateWithHighestVotesByState(state);
        }

        public async Task<CandidateDetailEntity> GetCandidateWithLeastVotesByState(string state)
        {
            return await _resultDAL.GetCandidateWithLeastVotesByState(state);
        }
    }
}
