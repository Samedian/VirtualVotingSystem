using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualVotingSystemEntities
{
    public class AddressDetailEntity
    {
        //bbb
        public Int64 AddressID { get; set; }

        public string HouseNumber { get; set; }

        public string StreetName { get; set; }

        public int WardNumber { get; set; }

        public string Town { get; set; }

        public string District { get; set; }

        public int Pincode { get; set; }

        public string State { get; set; }
    }
}
