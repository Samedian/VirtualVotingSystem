using System;
using System.Collections.Generic;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class UserId
    {
        public string Vvid { get; set; }
        public string Pass { get; set; }
        public long? AadharNumber { get; set; }
        public bool? IsCasted { get; set; }

        public virtual UserDetail AadharNumberNavigation { get; set; }
    }
}
