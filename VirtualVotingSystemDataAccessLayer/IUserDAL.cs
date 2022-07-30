using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
    public interface IUserDAL
    { 
        Task<List<CandidateDetailEntity>> GetCandidateByRegion(UserDetailEntity userDetailEntity);
        (UserIdEntity, UserDetailEntity) GetUserDetailsByVvid(string VVId);
        void CastVote(CandidateDetailEntity candidate, UserIdEntity userId);
        Task<CandidateDetailEntity> GetCandidateById(string candidateId);
        Task<UserIdEntity> GetUserIdDetailsByVvid(string vvId);
        Task<UserIdEntity> GetUserIdDetailsByAadhar(long aadharNo);
    }
}