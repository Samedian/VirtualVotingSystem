using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualVotingSystemBussinessLayer;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemMSTest
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        public async Task GetCandidateById()
        {
            CandidateDetailEntity candidateDetailEntity = new CandidateDetailEntity();
            UserDetailEntity userDetailEntity = new UserDetailEntity();
            var mock = new Mock<IUserDAL>();
            string candidateId = null;
            mock.Setup(p => p.GetCandidateById(candidateId)).Returns(Task.FromResult(candidateDetailEntity));
            //act
            UserBAL userBAL = new UserBAL(mock.Object);
            //arrange
            CandidateDetailEntity actualcandidateDetailEntity = new CandidateDetailEntity();

            //act
            CandidateDetailEntity expectedcandidateDetailEntity = await userBAL.GetCandidateById(candidateId);
            //assert
            Assert.AreNotEqual(expectedcandidateDetailEntity, actualcandidateDetailEntity);


        }
        public static IEnumerable<object[]> GetDataDeleteCandidate()
        {
            yield return new object[] { "OD18LS01", true };
            yield return new object[] { "OD18LS02", true };
            yield return new object[] { "OD18LS03", true };
            yield return new object[] { "OD18LS04", true };

        }
        [TestMethod]
        public async Task GetUserIdDetailsByVvid()
        {
            UserIdEntity userIdEntity = new UserIdEntity();
            var mock = new Mock<IUserDAL>();
            string vvid = null;
            mock.Setup(p => p.GetUserIdDetailsByVvid(vvid)).Returns(Task.FromResult(userIdEntity));
            //act
            UserBAL userBAL = new UserBAL(mock.Object);
            //arrange
            UserIdEntity actualUserIdEntity = new UserIdEntity();

            //act
            UserIdEntity expectedUserIdEntity = await userBAL.GetUserIdDetailsByVvid(vvid);
            //assert
            Assert.AreNotEqual(actualUserIdEntity, expectedUserIdEntity);


        }
    }
}