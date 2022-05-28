using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemDataAccessLayer.Model;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemMSTest
{
    [TestClass]
    public class AdminTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetDataAddAdmin), DynamicDataSourceType.Method)]
        public async Task AddAdmin(string loginId, string password, bool result)
        {

            var mock = new Mock<IAdminDAL>();
            AdminCredentialEntity adminCredentials = new AdminCredentialEntity();
            adminCredentials.LoginId = loginId;
            adminCredentials.Pass = password;
            mock.Setup(p => p.AddAdmin(adminCredentials)).Returns(Task.FromResult(result));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            bool expectedResult = result;

            //act
            bool actualResult = await adminBAL.AddAdmin(adminCredentials);
            //assert
            Assert.AreEqual(actualResult, expectedResult);


        }
        public static IEnumerable<object[]> GetDataAddAdmin()
        {
            yield return new object[] { "m1060972", "Rama", false };
            yield return new object[] { "M1060952", "Hasini", true };
            yield return new object[] { "m1060971", "ABC", true };
        }
        [DataTestMethod]
        [DynamicData(nameof(GetDataUpdateAdmin), DynamicDataSourceType.Method)]
        public async Task UpdateAdmin(string loginId, string password)
        {

            var mock = new Mock<IAdminDAL>();
            AdminCredentialEntity adminCredentials = new AdminCredentialEntity();
            adminCredentials.LoginId = loginId;
            adminCredentials.Pass = password;
            mock.Setup(p => p.UpdateAdmin(adminCredentials)).Returns(Task.FromResult(adminCredentials));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            AdminCredentialEntity expectedAdminCredentials = adminCredentials;

            //act
            AdminCredentialEntity actualAdminCredentials = await adminBAL.UpdateAdmin(adminCredentials);
            //assert
            Assert.AreEqual(expectedAdminCredentials, actualAdminCredentials);


        }
        public static IEnumerable<object[]> GetDataUpdateAdmin()
        {
            yield return new object[] { "m1060973", "rama" };
            yield return new object[] { "m1060953", "hasini" };

        }
        [DataTestMethod]
        [DynamicData(nameof(GetDataAddCandidate), DynamicDataSourceType.Method)]
        public async Task AddCandidate(string CandidateID, string CandidateName, long AadharNumber, string candidateParty, int votes, string state, bool result)
        {

            var mock = new Mock<IAdminDAL>();
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            candidateDetailEntity.CandidateId = CandidateID;
            candidateDetailEntity.CandidateName = CandidateName;
            candidateDetailEntity.CandidateParty = candidateParty;
            candidateDetailEntity.AadharNumber = AadharNumber;
            candidateDetailEntity.Votes = votes;

            mock.Setup(p => p.AddCandidate(candidateDetailEntity)).Returns(Task.FromResult(result));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            bool expectedResult = result;

            //act
            bool actualResult = await adminBAL.AddCandidate(candidateDetailEntity);
            //assert
            Assert.AreEqual(actualResult, expectedResult);


        }
        public static IEnumerable<object[]> GetDataAddCandidate()
        {
            yield return new object[] { "OD18LS01", "Alpha", 123456789170, "KALINGA", 0, "ODISHA", false };
            yield return new object[] { "OD18LS02", "Beta", 123456789171, "PURI", 0, "ODISHA", false };
            yield return new object[] { "OD18LS03", "Gaama", 123456789172, "BHUBANESHWAR", 0, "ODISHA", false };
            yield return new object[] { "OD18LS04", "Delta", 123456789173, "KONARK", 0, "ODISHA", false };

        }
        [DataTestMethod]
        [DynamicData(nameof(GetDataUpdateCandidate), DynamicDataSourceType.Method)]
        public async Task UpdateCandidate(string CandidateID, string CandidateName, long AadharNumber, string candidateParty, int votes, string state)

        {

            var mock = new Mock<IAdminDAL>();
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            candidateDetailEntity.CandidateId = CandidateID;
            candidateDetailEntity.CandidateName = CandidateName;
            candidateDetailEntity.CandidateParty = candidateParty;
            candidateDetailEntity.AadharNumber = AadharNumber;
            candidateDetailEntity.Votes = votes;

            mock.Setup(p => p.UpdateCandidate(candidateDetailEntity)).Returns(Task.FromResult(candidateDetailEntity));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            CandidateDetailEntity expectedCandidateDetailEntity = candidateDetailEntity;

            //act
            CandidateDetailEntity actualCandidateDetailEntity = await adminBAL.UpdateCandidate(candidateDetailEntity);
            //assert
            Assert.AreEqual(expectedCandidateDetailEntity, actualCandidateDetailEntity);


        }
        public static IEnumerable<object[]> GetDataUpdateCandidate()
        {
            yield return new object[] { "OD18LS01", "Alpha", 123456789170, "KALINGA", 0, "ODISHA" };
            yield return new object[] { "OD18LS02", "Beta", 123456789171, "PURI", 0, "ODISHA" };
            yield return new object[] { "OD18LS03", "Gaama", 123456789172, "BHUBANESHWAR", 0, "ODISHA" };
            yield return new object[] { "OD18LS04", "Delta", 123456789173, "KONARK", 0, "ODISHA" };

        }
        [DataTestMethod]
        [DynamicData(nameof(GetDataDeleteCandidate), DynamicDataSourceType.Method)]
        public async Task DeleteCandidate(string CandidateID, bool result)
        {

            var mock = new Mock<IAdminDAL>();



            mock.Setup(p => p.DeleteCandidate(CandidateID)).Returns(Task.FromResult(result));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            bool expectedResult = result;

            //act
            bool actualResult = await adminBAL.DeleteCandidate(CandidateID);
            //assert
            Assert.AreEqual(actualResult, expectedResult);



        }
        public static IEnumerable<object[]> GetDataDeleteCandidate()
        {
            yield return new object[] { "OD18LS01", true };
            yield return new object[] { "OD18LS02", true };
            yield return new object[] { "OD18LS03", true };
            yield return new object[] { "OD18LS04", true };

        }
        [TestMethod]
        public async Task GetCandidatesByState()
        {

            var mock = new Mock<IAdminDAL>();
            List<CandidateDetailEntity> candidateDetailEntityList = new List<CandidateDetailEntity>();
            string state = "Telangana";
            mock.Setup(p => p.GetCandidatesByState(state)).Returns(Task.FromResult(candidateDetailEntityList));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            List<CandidateDetailEntity> expectedCandidateDetailEntityList = null;

            //act
            List<CandidateDetailEntity> actualCandidateDetailEntityList = await adminBAL.GetCandidatesByState(state);
            //assert
            CollectionAssert.AreNotEqual(expectedCandidateDetailEntityList, actualCandidateDetailEntityList);


        }
        [TestMethod]
        public async Task GetCandidateById()
        {

            var mock = new Mock<IAdminDAL>();
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            string id = "TS18LS00";
            mock.Setup(p => p.GetCandidatesById(id)).Returns(Task.FromResult(candidateDetailEntity));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            CandidateDetailEntity expectedCandidateDetailEntity = null;

            //act
            CandidateDetailEntity actualCandidateDetailEntity = await adminBAL.GetCandidatesById(id);
            //assert
            Assert.AreNotEqual(expectedCandidateDetailEntity, actualCandidateDetailEntity);


        }
        [TestMethod]
        public async Task GetCandidates()
        {

            var mock = new Mock<IAdminDAL>();
            List<CandidateDetailEntity> candidateDetailEntityList = new List<CandidateDetailEntity>();


            mock.Setup(p => p.GetCandidates()).Returns(Task.FromResult(candidateDetailEntityList));
            //act
            AdminBAL adminBAL = new AdminBAL(mock.Object);
            //arrange
            List<CandidateDetailEntity> expectedCandidateDetailEntityList = null;

            //act
            List<CandidateDetailEntity> actualCandidateDetailEntityList = await adminBAL.GetCandidates();
            //assert
            CollectionAssert.AreNotEqual(expectedCandidateDetailEntityList, actualCandidateDetailEntityList);


        }

    }
}