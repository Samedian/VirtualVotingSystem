using VirtualVotingSystemEntities;

namespace VirtualVotingDemo
{
    public interface ISMS
    {
        string SendOTP(string MobileNumber);
        void SendPassword(string MobileNumber, UserIdEntity userIdEntity);
    }
}