using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualVotingSystemEntities;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemExceptions;
using System.Threading.Tasks;

namespace VirtualVotingSystemDataAccessLayer
{
    public class UserDAL : IUserDAL
    {
        private readonly IModelToEntityManager _modelToEntityManager;
        public UserDAL(IModelToEntityManager modelToEntityManager)
        {
            _modelToEntityManager = modelToEntityManager;
        }

        //This Function returns UserId and UserDetail data by VVId
        public (UserIdEntity , UserDetailEntity) GetUserDetailsByVvid(string VVId)
        {

            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var userDetail = context.UserIds.Find(VVId);
                    
                    var addressDetail = 
                   (from address in context.AddressDetails
                    join user in context.UserDetails on address.AddressId equals user.AddressId
                    where user.AadharNumber == userDetail.AadharNumber
                    select address).FirstOrDefault();

                    if (addressDetail == null)
                    {
                        throw new DataNotFound("Data Not Found for this record");
                    }

                    var userdata = context.UserDetails.FirstOrDefault(user =>
                        user.AadharNumber == userDetail.AadharNumber);

                    UserIdEntity userIdEntity = _modelToEntityManager.GetUserIdEntity(userDetail);
                    UserDetailEntity userDetailEntity = _modelToEntityManager.GetUserDetailEntity(userdata, addressDetail);


                    return (userIdEntity,userDetailEntity);

                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }

        }

        public async Task<List<CandidateDetailEntity>> GetCandidateByRegion(UserDetailEntity userDetailEntity)
        {
            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var candidate = (from u in context.UserIds
                                     join us in context.UserDetails on u.AadharNumber equals us.AadharNumber
                                     join a in context.AddressDetails on us.AddressId equals a.AddressId
                                     where a.ConstituencyState == userDetailEntity.GetAddressDetail.State
                                     join c in context.CandidateDetails on a.ConstituencyState equals c.ConstituencyState
                                     where c.ConstituencyState == userDetailEntity.GetAddressDetail.State 
                                     select c
                                    ).Distinct().ToList();

                    List<CandidateDetailEntity> candidateDetailEntity = _modelToEntityManager.GetCandidateEntity(candidate);

                    return await Task.FromResult(candidateDetailEntity);

                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }

        }

        public void CastVote(CandidateDetailEntity candidate, UserIdEntity userIdEntity)
        {
            UserId userId = _modelToEntityManager.GetUserId(userIdEntity);
            CandidateDetail candidateDetail = _modelToEntityManager.GetCandidateEntity(candidate);

            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var data = context.UserIds.FirstOrDefault(u => u.Vvid == userId.Vvid);
                    data.IsCasted = true;
                    context.SaveChanges();

                    var res = context.CandidateDetails.FirstOrDefault(c => c.CandidateId == candidateDetail.CandidateId);
                    int vote = res.Votes;
                    res.Votes = vote + 1;
                    context.SaveChanges();
                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }

        }

        public async Task<CandidateDetailEntity> GetCandidateById(string candidateId)
        {

            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var res = context.CandidateDetails.FirstOrDefault(c => c.CandidateId == candidateId);
                    CandidateDetailEntity candidateDetailEntity = _modelToEntityManager.GetOneCandidateEntity(res);
                    return await Task.FromResult(candidateDetailEntity);
                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }

        public async Task<UserIdEntity> GetUserIdDetailsByVvid(string vvId)
        {
            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var res = context.UserIds.Find(vvId);
                    UserIdEntity userIdEntity = _modelToEntityManager.GetUserIdEntity(res);
                    return await Task.FromResult(userIdEntity);
                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
        }
        public async Task<UserIdEntity> GetUserIdDetailsByAadhar(long aadharNo)
        {
            using (var context = new VirtualVotingSystemContext())
            {
                try
                {
                    var data = context.UserIds.FirstOrDefault(x => x.AadharNumber == aadharNo);
                    if (data != null)
                    {
                        UserIdEntity userIdEntity = _modelToEntityManager.GetUserIdEntity(data);
                        return await Task.FromResult(userIdEntity);
                    }
                    else
                        return null;

                }
                catch (SqlException ex)
                {
                    throw ex.InnerException;
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;

                }
            }
        }
    }
}
