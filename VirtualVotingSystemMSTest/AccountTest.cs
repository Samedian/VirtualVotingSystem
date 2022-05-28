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
    public class AccountTest
    {
        [DataTestMethod]
        [DynamicData(nameof(GetDataByAadhar), DynamicDataSourceType.Method)]
        public async Task GetUserDetailsByAadhar(long aadhar, string name, string gender, int mobilenumber, int addressId)
        {
            UserDetailEntity userIdEntity = new UserDetailEntity();
            userIdEntity.AadharNumber = aadhar;
            userIdEntity.UserName = name;

            userIdEntity.MobileNumber = mobilenumber;


            var mock = new Mock<IAccountDAL>();
            mock.Setup(p => p.GetUserDetailsByAadhar(aadhar.ToString())).Returns(Task.FromResult(userIdEntity));
            //act
            AccountBAL accountBAL = new AccountBAL(mock.Object);
            //arrange
            UserDetailEntity actualUserIdEntity = userIdEntity;

            //act
            UserDetailEntity expectedUserIdEntity = await accountBAL.GetUserDetailsByAadhar(aadhar.ToString());
            //assert
            Assert.AreEqual(actualUserIdEntity, expectedUserIdEntity);


        }
        public static IEnumerable<object[]> GetDataByAadhar()
        {
            yield return new object[] { 123456789017, "Gaya C", "Male", 1234567817, 32 };
            yield return new object[] { 123456789018, "Gaya D", "Male", 1234567818, 33 };
            yield return new object[] { 123456789019, "Gaya E", "Female", 1234567819, 34 };

        }

        [DataTestMethod]
        [DynamicData(nameof(GetDataId), DynamicDataSourceType.Method)]
        public async Task SaveId(long aadhar, string result)
        {
            UserIdEntity userIdEntity = new UserIdEntity();
            var mock = new Mock<IAccountDAL>();
            userIdEntity.AadharNumber = aadhar;

            mock.Setup(p => p.SaveId(userIdEntity)).Returns(Task.FromResult(result));
            //act
            AccountBAL accountBAL = new AccountBAL(mock.Object);
            //arrange
            string expectedResult = result;

            //act
            string actualResult = await accountBAL.SaveId(userIdEntity);
            //assert
            Assert.AreEqual(actualResult, expectedResult);


        }
        public static IEnumerable<object[]> GetDataId()
        {
            yield return new object[] { 123456789001, "You have Registred" };
            yield return new object[] { 123456789002, "You have Registred" };
            yield return new object[] { 123456789999, "Success" };
        }
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public async Task Login(string loginId, string password, string role)
        {

            var mock = new Mock<IAccountDAL>();


            mock.Setup(p => p.Login(loginId, password)).Returns(Task.FromResult(role));
            //act
            AccountBAL accountBAL = new AccountBAL(mock.Object);
            //arrange
            string expectedRole = role;

            //act
            string actualRole = await accountBAL.Login(loginId, password);
            //assert
            Assert.AreEqual(actualRole, expectedRole);


        }
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "m1060971", "rama", "Admin" };
            yield return new object[] { "m1060951", "hasini", "Admin" };
            yield return new object[] { "BI38TT9016ST", "Gaya A", "User" };
        }
    }
}