using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
   public class ResultDAL:IResultDAL
    {
        public async Task<CandidateDetailEntity> GetCandidateWithHighestVotesByState(string state)
        {
            CandidateDetailEntity candidateDetailEntity1 = new CandidateDetailEntity();
            CandidateDetail candidateDetail = new CandidateDetail();
            List<CandidateDetail> allCandidates = new List<CandidateDetail>();
            List<CandidateDetailEntity> candidateDetailsByStateEntity = new List<CandidateDetailEntity>();
            int count = 0;
            string candidateId = null;
            List<CandidateDetail> candidateDetailsByState = new List<CandidateDetail>();
            using (var context = new VirtualVotingSystemContext())
            {
                allCandidates = context.CandidateDetails.ToList();
                foreach (CandidateDetail candidate in allCandidates)
                {
                    if (candidate.ConstituencyState.Equals(state) == true)
                    {
                        CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
                        candidateDetailEntity.CandidateId = candidate.CandidateId;
                        candidateDetailEntity.CandidateName = candidate.CandidateName;
                        candidateDetailEntity.CandidateParty = candidate.CandidateParty;
                        candidateDetailEntity.ConstituencyState = candidate.ConstituencyState;
                        candidateDetailEntity.AadharNumber = (long)candidate.AadharNumber;
                        candidateDetailEntity.Votes = candidate.Votes;

                        candidateDetailsByStateEntity.Add(candidateDetailEntity);
                    }
                }
                foreach (CandidateDetailEntity candidate1 in candidateDetailsByStateEntity)
                {
                    if (candidate1.Votes > count)
                    {
                        count = candidate1.Votes;
                        candidateId = candidate1.CandidateId;
                    }
                }

                candidateDetail = context.CandidateDetails.Where(c => c.CandidateId.Equals(candidateId) == true).FirstOrDefault();

                candidateDetailEntity1.CandidateId = candidateDetail.CandidateId;
                candidateDetailEntity1.CandidateName = candidateDetail.CandidateName;
                candidateDetailEntity1.CandidateParty = candidateDetail.CandidateParty;
                candidateDetailEntity1.ConstituencyState = candidateDetail.ConstituencyState;
                candidateDetailEntity1.AadharNumber = (long)candidateDetail.AadharNumber;
                candidateDetailEntity1.Votes = candidateDetail.Votes;

            }
            return await Task.FromResult(candidateDetailEntity1);
        }
        public async Task<CandidateDetailEntity> GetCandidateWithLeastVotesByState(string state)
        {
            CandidateDetailEntity candidateDetailEntity1 = new CandidateDetailEntity();
            CandidateDetail candidateDetail = new CandidateDetail();
            List<CandidateDetail> allCandidates = new List<CandidateDetail>();
            List<CandidateDetailEntity> candidateDetailsByStateEntity = new List<CandidateDetailEntity>();
            int count = 0;
            string cid = null;
            string candidateId = null;
            List<CandidateDetail> candidateDetailsByState = new List<CandidateDetail>();
            using (var context = new VirtualVotingSystemContext())
            {
                allCandidates = context.CandidateDetails.ToList();
                foreach (CandidateDetail candidate in allCandidates)
                {
                    if (candidate.ConstituencyState.Equals(state) == true)
                    {
                        CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
                        candidateDetailEntity.CandidateId = candidate.CandidateId;
                        candidateDetailEntity.CandidateName = candidate.CandidateName;
                        candidateDetailEntity.CandidateParty = candidate.CandidateParty;
                        candidateDetailEntity.ConstituencyState = candidate.ConstituencyState;
                        candidateDetailEntity.AadharNumber = (long)candidate.AadharNumber;
                        candidateDetailEntity.Votes = candidate.Votes;

                        candidateDetailsByStateEntity.Add(candidateDetailEntity);
                        count = candidateDetailEntity.Votes;
                        cid = candidateDetailEntity.CandidateId;
                    }
                }
                foreach (CandidateDetailEntity candidate1 in candidateDetailsByStateEntity)
                {
                    if (candidate1.Votes < count)
                    {
                        count = candidate1.Votes;
                        candidateId = candidate1.CandidateId;
                    }

                }
                if (candidateId == null)
                {
                    candidateId = cid;
                }
                candidateDetail = context.CandidateDetails.Where(c => c.CandidateId.Equals(candidateId) == true).FirstOrDefault();

                candidateDetailEntity1.CandidateId = candidateDetail.CandidateId;
                candidateDetailEntity1.CandidateName = candidateDetail.CandidateName;
                candidateDetailEntity1.CandidateParty = candidateDetail.CandidateParty;
                candidateDetailEntity1.ConstituencyState = candidateDetail.ConstituencyState;
                candidateDetailEntity1.AadharNumber = (long)candidateDetail.AadharNumber;
                candidateDetailEntity1.Votes = candidateDetail.Votes;

            }
            return await Task.FromResult(candidateDetailEntity1);
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

    }
}
