using System;
using System.Threading.Tasks;
using VirtualVotingSystemDataAccessLayer;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public class AccountBAL : IAccountBAL
    {
        private readonly IAccountDAL _accountDAL;
        public AccountBAL(IAccountDAL accountDAL)
        {
            _accountDAL = accountDAL;
        }

        //get user details by aadhar 
        public  async Task<UserDetailEntity> GetUserDetailsByAadhar(string aadharNumber)
        {
            UserDetailEntity userDetailEntity = await  _accountDAL.GetUserDetailsByAadhar(aadharNumber);
            return await Task.FromResult(userDetailEntity);
            //return  new Task<UserDetailEntity>(() => userDetailEntity);

        }

        public async Task<string> Login(string UserName, string Password)
        {
            string role = await  _accountDAL.Login(UserName, Password);

            return await Task.FromResult(role);
        }

        public async Task<string> SaveId(UserIdEntity userIdEntity)
        {
            string result = await _accountDAL.SaveId(userIdEntity);
            return await Task.FromResult(result);
        }
    }
}
