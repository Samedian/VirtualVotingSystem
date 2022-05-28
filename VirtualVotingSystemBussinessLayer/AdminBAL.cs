using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
   public  class AdminBAL:IAdminBAL
    {
        private IAdminDAL _adminDAL;
        public AdminBAL(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }
        public async Task<bool> AddAdmin(AdminCredentialEntity admin)
        {
            return await _adminDAL.AddAdmin(admin);
        }

        public async Task<bool> AddCandidate(CandidateDetailEntity candidateDetailEntity)
        {
            return await _adminDAL.AddCandidate(candidateDetailEntity);
        }

        public async Task<bool> DeleteCandidate(string CandidateId)
        {
            return await _adminDAL.DeleteCandidate(CandidateId);
        }

        public async Task<List<CandidateDetailEntity>> GetCandidates()
        {

            return await _adminDAL.GetCandidates();      
        }

        public async Task<CandidateDetailEntity> GetCandidatesById(string Id)
        {
            return await _adminDAL.GetCandidatesById(Id);
        }

        public async Task<List<CandidateDetailEntity>> GetCandidatesByState(string state)
        {
            return await _adminDAL.GetCandidatesByState(state);
        }

        public async Task<AdminCredentialEntity> UpdateAdmin(AdminCredentialEntity admin)
        {
            return await _adminDAL.UpdateAdmin(admin);
        }

        public async Task<CandidateDetailEntity> UpdateCandidate(CandidateDetailEntity candidateDetailEntity)
        {
            return await _adminDAL.UpdateCandidate(candidateDetailEntity);
        }
    }
}
