using System;
using System.Threading.Tasks;

namespace VirtualVotingSystemEntities
{
    public class UserDetailEntity
    {
        public Int64 AadharNumber { get; set; }

        public string UserName { get; set; }

        public string Gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public Int64 MobileNumber { get; set; }

        public AddressDetailEntity GetAddressDetail { get; set; }

    }
}
