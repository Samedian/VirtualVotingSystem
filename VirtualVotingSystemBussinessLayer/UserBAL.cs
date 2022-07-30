using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public class UserBAL : IUserBAL
    {
        private readonly IUserDAL _userDAL;
        public UserBAL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public (UserIdEntity,UserDetailEntity) GetUserDetailsByVvid(string VVId)
        {
            (UserIdEntity userIdEntity ,UserDetailEntity userDetailEntity) = _userDAL.GetUserDetailsByVvid(VVId);
            return (userIdEntity,userDetailEntity);
        }
            public async Task<List<CandidateDetailEntity>> GetCandidateByRegion(UserDetailEntity userDetail)
        {
            List<CandidateDetailEntity> candidateDetailEntities = await _userDAL.GetCandidateByRegion(userDetail);
            return candidateDetailEntities;
        }

        public void CastVote(CandidateDetailEntity candidate, UserIdEntity userId)
        {
            _userDAL.CastVote(candidate, userId);
        }

        public async Task<CandidateDetailEntity> GetCandidateById(string candidateId)
        {
            CandidateDetailEntity candidateDetailEntity = await _userDAL.GetCandidateById(candidateId);
            return candidateDetailEntity;
        }

        public async Task<UserIdEntity> GetUserIdDetailsByVvid(string vvId)
        {
            UserIdEntity userIdEntity = await _userDAL.GetUserIdDetailsByVvid(vvId);
            return userIdEntity;
        }

        public async Task<UserIdEntity> GetUserIdByAadhar(long aadharNo)
        {
            UserIdEntity result = await _userDAL.GetUserIdDetailsByAadhar(aadharNo);
            return await Task.FromResult(result);
        }
    }

}
