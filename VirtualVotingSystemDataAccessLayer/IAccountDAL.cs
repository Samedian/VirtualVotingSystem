using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemDataAccessLayer
{
    public interface IAccountDAL
    {
        Task<UserDetailEntity> GetUserDetailsByAadhar(string AadharNumber);
        Task<string> Login(string UserName, string Password);
        Task<string> SaveId(UserIdEntity userIdEntity);
    }
}