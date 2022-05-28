using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
    public interface IModelToEntityManager
    {
        UserDetailEntity GetUserDetailEntity(UserDetail userDetail, AddressDetail addressDetail);
        List<CandidateDetailEntity> GetCandidateEntity(List<CandidateDetail> data);
        UserIdEntity GetUserIdEntity(UserId userDetail);
        UserId GetUserId(UserIdEntity userIdEntity);
        CandidateDetail GetCandidateEntity(CandidateDetailEntity candidate);
        CandidateDetailEntity GetOneCandidateEntity(CandidateDetail res);
    }
}