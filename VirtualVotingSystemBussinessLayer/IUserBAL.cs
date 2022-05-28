using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public interface IUserBAL
    {
        Task<List<CandidateDetailEntity>> GetCandidateByRegion(UserDetailEntity userDetailEntity);
        (UserIdEntity, UserDetailEntity) GetUserDetailsByVvid(string VVId);
        void CastVote(CandidateDetailEntity candidate, UserIdEntity userId);
        Task<CandidateDetailEntity> GetCandidateById(string candidateId);
        Task<UserIdEntity> GetUserIdDetailsByVvid(string vvId);
    }
}