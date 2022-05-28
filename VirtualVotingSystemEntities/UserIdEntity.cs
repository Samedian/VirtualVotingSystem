using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualVotingSystemEntities
{
    public class UserIdEntity
    {
        public string Vvid { get; set; }
        public string Pass { get; set; }
        public long? AadharNumber { get; set; }
        public bool? IsCasted { get; set; }
    }
}
