using System.Threading.Tasks;
using VirtualVotingSystemEntities;

namespace VirtualVotingSystemBussinessLayer
{
    public interface IAccountBAL
    {
        Task<UserDetailEntity> GetUserDetailsByAadhar(string AadharNumber);
        Task<string> Login(string UserName, string Password);
        Task<string> SaveId(UserIdEntity userIdEntity);
    }
}