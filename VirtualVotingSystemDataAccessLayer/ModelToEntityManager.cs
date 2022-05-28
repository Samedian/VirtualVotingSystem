using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
    public class ModelToEntityManager : IModelToEntityManager
    {
        public List<CandidateDetailEntity> GetCandidateEntity(List<CandidateDetail> data)
        {
            List<CandidateDetailEntity> candidateDetailEntities = new List<CandidateDetailEntity>();
            foreach (var item in data)
            {
                CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
                candidateDetailEntity.CandidateId = item.CandidateId;
                candidateDetailEntity.CandidateName = item.CandidateName;
                candidateDetailEntity.CandidateParty = item.CandidateParty;
                candidateDetailEntity.AadharNumber = (long)item.AadharNumber;
                candidateDetailEntity.ConstituencyState = item.ConstituencyState;

                candidateDetailEntities.Add(candidateDetailEntity);
            }
            return candidateDetailEntities;
        }

        public CandidateDetail GetCandidateEntity(CandidateDetailEntity candidateDetailEntity)
        {

            CandidateDetail candidateDetail = new CandidateDetail();
            candidateDetail.CandidateId = candidateDetailEntity.CandidateId;
            candidateDetail.CandidateName = candidateDetailEntity.CandidateName;
            candidateDetail.CandidateParty = candidateDetailEntity.CandidateParty;
            candidateDetail.AadharNumber = (long)candidateDetailEntity.AadharNumber;
            candidateDetail.ConstituencyState = candidateDetailEntity.ConstituencyState;

            return candidateDetail;

        }

        public CandidateDetailEntity GetOneCandidateEntity(CandidateDetail item)
        {
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            candidateDetailEntity.CandidateId = item.CandidateId;
            candidateDetailEntity.CandidateName = item.CandidateName;
            candidateDetailEntity.CandidateParty = item.CandidateParty;
            candidateDetailEntity.AadharNumber = (long)item.AadharNumber;
            candidateDetailEntity.ConstituencyState = item.ConstituencyState;

            return candidateDetailEntity;

        }

        public UserDetailEntity GetUserDetailEntity(UserDetail userDetail, AddressDetail addressDetail)
        {

            UserDetailEntity userDetailEntity = new UserDetailEntity();
            AddressDetailEntity addressDetailEntity = new AddressDetailEntity();

            addressDetailEntity.AddressID = addressDetail.AddressId;
            addressDetailEntity.HouseNumber = addressDetail.HouseNumber;
            addressDetailEntity.StreetName = addressDetail.StreetName;
            addressDetailEntity.District = addressDetail.DistrictName;
            addressDetailEntity.WardNumber = addressDetail.WardNumber;
            addressDetailEntity.Town = addressDetail.TownName;
            addressDetailEntity.StreetName = addressDetail.StreetName;
            addressDetailEntity.Pincode = addressDetail.Pincode;
            addressDetailEntity.State = addressDetail.ConstituencyState;

            userDetailEntity.AadharNumber = userDetail.AadharNumber;
            userDetailEntity.UserName = userDetail.UserName;
            userDetailEntity.Gender = userDetail.Gender;
            userDetailEntity.DateofBirth = userDetail.DateOfBirth;
            userDetailEntity.MobileNumber = userDetail.MobileNumber;
            userDetailEntity.GetAddressDetail = addressDetailEntity;

            return userDetailEntity;
            //return new Task<UserDetailEntity>(() => userDetailEntity);
        }

        public UserId GetUserId(UserIdEntity userIdEntity)
        {
            UserId userId = new UserId();
            userId.AadharNumber = userIdEntity.AadharNumber;
            userId.Vvid = userIdEntity.Vvid;
            userId.Pass = userIdEntity.Pass;
            userId.IsCasted = userIdEntity.IsCasted;

            return userId;
        }

        public UserIdEntity GetUserIdEntity(UserId userDetail)
        {
            UserIdEntity userIdEntity = new UserIdEntity();
            userIdEntity.AadharNumber = userDetail.AadharNumber;
            userIdEntity.Vvid = userDetail.Vvid;
            userIdEntity.Pass = userDetail.Pass;
            userIdEntity.IsCasted = userDetail.IsCasted;

            return userIdEntity;
        }
    }
}
