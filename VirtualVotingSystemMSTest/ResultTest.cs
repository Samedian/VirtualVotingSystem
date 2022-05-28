using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemMSTest
{
    [TestClass]
    public class ResultTest
    {
        [TestMethod]
        public async Task GetCandidateWithHighestVotesByState()
        {

            var mock = new Mock<IResultDAL>();
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            string state = "Telangana";
            mock.Setup(p => p.GetCandidateWithHighestVotesByState(state)).Returns(Task.FromResult(candidateDetailEntity));
            //act
            ResultBAL resultBAL = new ResultBAL(mock.Object);
            //arrange
            CandidateDetailEntity expectedCandidateDetailEntity = null;

            //act
            CandidateDetailEntity actualCandidateDetailEntity = await resultBAL.GetCandidateWithHighestVotesByState(state);
            //assert
            Assert.AreNotEqual(expectedCandidateDetailEntity, actualCandidateDetailEntity);


        }
        [TestMethod]
        public async Task GetCandidateWithLeastVotesByState()
        {

            var mock = new Mock<IResultDAL>();
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            string state = "Telangana";
            mock.Setup(p => p.GetCandidateWithLeastVotesByState(state)).Returns(Task.FromResult(candidateDetailEntity));
            //act
            ResultBAL resultBAL = new ResultBAL(mock.Object);
            //arrange
            CandidateDetailEntity expectedCandidateDetailEntity = candidateDetailEntity;

            //act
            CandidateDetailEntity actualCandidateDetailEntity = await resultBAL.GetCandidateWithLeastVotesByState(state);
            //assert
            Assert.AreEqual(expectedCandidateDetailEntity, actualCandidateDetailEntity);


        }
        [TestMethod]
        public async Task GetCandidatesByState()
        {

            var mock = new Mock<IResultDAL>();
            List<CandidateDetailEntity> candidateDetailEntityList = new List<CandidateDetailEntity>();
            string state = "Telangana";
            mock.Setup(p => p.GetCandidatesByState(state)).Returns(Task.FromResult(candidateDetailEntityList));
            //act
            ResultBAL resultBAL = new ResultBAL(mock.Object);
            //arrange
            List<CandidateDetailEntity> expectedCandidateDetailEntityList = candidateDetailEntityList;

            //act
            List<CandidateDetailEntity> actualCandidateDetailEntityList = await resultBAL.GetCandidatesByState(state);
            //assert
            CollectionAssert.AreEqual(expectedCandidateDetailEntityList, actualCandidateDetailEntityList);


        }
        [TestMethod]
        public async Task GetCandidates()
        {

            var mock = new Mock<IResultDAL>();
            List<CandidateDetailEntity> candidateDetailEntityList = new List<CandidateDetailEntity>();
            mock.Setup(p => p.GetCandidates()).Returns(Task.FromResult(candidateDetailEntityList));
            //act
            ResultBAL resultBAL = new ResultBAL(mock.Object);
            //arrange
            List<CandidateDetailEntity> expectedCandidateDetailEntityList = candidateDetailEntityList;

            //act
            List<CandidateDetailEntity> actualCandidateDetailEntityList = await resultBAL.GetCandidates();
            //assert
            Assert.AreEqual(expectedCandidateDetailEntityList, actualCandidateDetailEntityList);


        }
    }
}