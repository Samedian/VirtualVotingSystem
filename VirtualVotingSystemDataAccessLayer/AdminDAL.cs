using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;
using VirtualVotingSystemExceptions;

namespace VirtualVotingSystemDataAccessLayer
{
   public class AdminDAL:IAdminDAL
    {

        public async Task<bool> AddAdmin(AdminCredentialEntity admin)
        {
            try
            {
                using (var context = new VirtualVotingSystemContext())
                {
                    AdminCredential adminCredential = new AdminCredential();
                    adminCredential.LoginId = admin.LoginId;
                    adminCredential.Pass = admin.Pass;
                    context.AdminCredentials.Add(adminCredential);
                    context.SaveChanges();
                }
            }
            catch(DataNotFound)
            {
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            return await Task.FromResult(true);

        }
        public async Task<AdminCredentialEntity> UpdateAdmin(AdminCredentialEntity admin)
        {
            
            try
            {
                AdminCredential adminCredential = new AdminCredential();
                using (var context = new VirtualVotingSystemContext())
                {
                    var data = context.AdminCredentials.FirstOrDefault(x=>x.LoginId==admin.LoginId);
                    if(data==null)
                    {
                        throw new DataNotFound("Invalid Id...");
                    }
                    adminCredential = context.AdminCredentials.Where(c => c.LoginId == admin.LoginId).FirstOrDefault();
                    adminCredential.Pass = admin.Pass;
                    context.SaveChanges();
                    return await Task.FromResult(admin);
                }
            }
            catch(DataNotFound)
            {
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
        public async Task<bool> AddCandidate(CandidateDetailEntity candidateDetailEntity)
        {
            CandidateDetail c = new CandidateDetail();
            bool res = false;
            try {
                using (var context = new VirtualVotingSystemContext())
                {
                    c = context.CandidateDetails.Where(c => c.AadharNumber == candidateDetailEntity.AadharNumber).FirstOrDefault();
                    if (c == null)
                    {
                        List<UserDetail> users = context.UserDetails.ToList();
                        foreach (UserDetail user in users)
                        {
                            if (user.AadharNumber == candidateDetailEntity.AadharNumber)
                            {
                                CandidateDetail candidateDetail = new CandidateDetail();
                                candidateDetail.CandidateId = candidateDetailEntity.CandidateId;
                                candidateDetail.CandidateName = candidateDetailEntity.CandidateName;
                                candidateDetail.CandidateParty = candidateDetailEntity.CandidateParty;

                                candidateDetail.AadharNumber = candidateDetailEntity.AadharNumber;

                                candidateDetail.AadharNumberNavigation = context.UserDetails.Where(c => c.AadharNumber == candidateDetail.AadharNumber).FirstOrDefault();
                                long addressId = (long)candidateDetail.AadharNumberNavigation.AddressId;
                                AddressDetail adressEntity = context.AddressDetails.Where(c => c.AddressId == addressId).FirstOrDefault();
                                candidateDetail.ConstituencyState = adressEntity.ConstituencyState;

                                context.CandidateDetails.Add(candidateDetail);
                                context.SaveChanges();
                                return await Task.FromResult(true);
                            }
                        }
                    }
                }
            }
          
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        
            return await Task.FromResult(res);
        }
        public async Task<CandidateDetailEntity> UpdateCandidate(CandidateDetailEntity candidateDetail)
        {
            try
            {
                CandidateDetail candidate = new CandidateDetail();
                using (var context = new VirtualVotingSystemContext())
                {
                    candidate = context.CandidateDetails.Where(c => c.CandidateId == candidateDetail.CandidateId).FirstOrDefault();
                    var data = context.CandidateDetails.FirstOrDefault(x => x.CandidateId == candidateDetail.CandidateId);
                    if (data == null)
                    {
                        throw new DataNotFound("Invalid Id...");
                    }
                    candidate.CandidateName = candidateDetail.CandidateName;
                    candidate.AadharNumber = candidateDetail.AadharNumber;

                    context.SaveChanges();
                }
            }
            catch (DataNotFound)
            {
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
            return await Task.FromResult(candidateDetail);
        }
        public async Task<bool> DeleteCandidate(string CandidateId)
        {
            try
            {
                bool res = false;
                using (var context = new VirtualVotingSystemContext())
                {
                    CandidateDetail can = context.CandidateDetails.Where(c => c.CandidateId == CandidateId).FirstOrDefault();
                    context.CandidateDetails.Remove(can);
                    context.SaveChanges();
                    res = true;
                    return await Task.FromResult(res);
                }
            }
            catch (DataNotFound)
            {
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<List<CandidateDetailEntity>> GetCandidatesByState(string state)
        {
            List<CandidateDetailEntity> candidateDetailsByState = new List<CandidateDetailEntity>();
            try
            {
                using (var context = new VirtualVotingSystemContext())
                {
                    List<CandidateDetail> allCandidates = context.CandidateDetails.ToList();
                    foreach (CandidateDetail candidate in allCandidates)
                    {
                        if (candidate.ConstituencyState.Equals(state) == true)
                        {

                            CandidateDetailEntity candidateDetail = new CandidateDetailEntity();
                            candidateDetail.CandidateId = candidate.CandidateId;
                            candidateDetail.CandidateName = candidate.CandidateName;
                            candidateDetail.CandidateParty = candidate.CandidateParty;
                            candidateDetail.ConstituencyState = candidate.ConstituencyState;
                            candidateDetail.AadharNumber = (long)candidate.AadharNumber;
                            candidateDetail.Votes = candidate.Votes;
                            candidateDetailsByState.Add(candidateDetail);
                        }
                    }
                }
                if(candidateDetailsByState is null)
                {
                    throw new DataNotFound("data is not found");
                }
            }
            catch(DataNotFound ex)
            {
                throw ex.InnerException;
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return await Task.FromResult(candidateDetailsByState);
        }
        public async Task<List<CandidateDetailEntity>> GetCandidates()
        {
            List<CandidateDetail> allCandidates = new List<CandidateDetail>();
            List<CandidateDetailEntity> allCandidatesEntity = new List<CandidateDetailEntity>();
            try
            {
                using (var context = new VirtualVotingSystemContext())
                {
                    allCandidates = context.CandidateDetails.ToList();

                }
                foreach (CandidateDetail candidate in allCandidates)
                {
                    CandidateDetailEntity candidateDetail = new CandidateDetailEntity();
                    candidateDetail.CandidateId = candidate.CandidateId;
                    candidateDetail.CandidateName = candidate.CandidateName;
                    candidateDetail.CandidateParty = candidate.CandidateParty;
                    candidateDetail.ConstituencyState = candidate.ConstituencyState;
                    candidateDetail.AadharNumber = (long)candidate.AadharNumber;
                    candidateDetail.Votes = candidate.Votes;

                    allCandidatesEntity.Add(candidateDetail);
                }
                if (allCandidatesEntity is null)
                {
                    throw new DataNotFound("data is not found");
                }
            }
            catch (DataNotFound ex)
            {
                throw ex.InnerException;
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return await Task.FromResult(allCandidatesEntity);
        }
        public async Task<CandidateDetailEntity> GetCandidatesById(string Id)
        {
            CandidateDetailEntity cand = new CandidateDetailEntity();
            try
            {
                using (var context = new VirtualVotingSystemContext())
                {
                    List<CandidateDetail> allCandidates = context.CandidateDetails.ToList();
                    foreach (CandidateDetail candidate in allCandidates)
                    {
                        if (candidate.CandidateId == Id)
                        {
                            CandidateDetailEntity candidateDetail = new CandidateDetailEntity();
                            candidateDetail.CandidateId = candidate.CandidateId;
                            candidateDetail.CandidateName = candidate.CandidateName;
                            candidateDetail.CandidateParty = candidate.CandidateParty;
                            candidateDetail.ConstituencyState = candidate.ConstituencyState;
                            candidateDetail.AadharNumber = (long)candidate.AadharNumber;
                            candidateDetail.Votes = candidate.Votes;
                            cand = candidateDetail;
                            return await Task.FromResult(candidateDetail);
                        }
                    }
                    
                }
                
                if (cand is null)
                {
                    throw new DataNotFound("data is not found");
                }

            }
            catch (DataNotFound ex)
            {
                throw ex.InnerException;
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return await Task.FromResult(cand);
        }
    }
}
