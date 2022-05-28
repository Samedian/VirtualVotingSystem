using VirtualVotingSystemEntities;

namespace VirtualVotingSystem
{
    public interface IGenerateID
    {
        string GenerateId(UserDetailEntity userDetailEntity);
    }
}