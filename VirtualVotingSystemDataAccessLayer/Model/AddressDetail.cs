using System;
using System.Collections.Generic;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class AddressDetail
    {
        public AddressDetail()
        {
            UserDetails = new HashSet<UserDetail>();
        }

        public long AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public int WardNumber { get; set; }
        public string TownName { get; set; }
        public int Pincode { get; set; }
        public string DistrictName { get; set; }
        public string ConstituencyState { get; set; }

        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
