using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public interface IAdminBAL
    {
        Task<bool> AddAdmin(AdminCredentialEntity admin);

        Task<AdminCredentialEntity> UpdateAdmin(AdminCredentialEntity admin);
        Task<bool> AddCandidate(CandidateDetailEntity candidateDetailEntity);
        Task<CandidateDetailEntity> UpdateCandidate(CandidateDetailEntity candidateDetailEntity);
        Task<bool> DeleteCandidate(string candidateDetailEntity);
        Task<List<CandidateDetailEntity>> GetCandidatesByState(string state);
        Task<CandidateDetailEntity> GetCandidatesById(string Id);
        Task<List<CandidateDetailEntity>> GetCandidates();
    }
}
