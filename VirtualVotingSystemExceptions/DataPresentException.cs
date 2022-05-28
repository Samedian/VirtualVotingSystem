using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualVotingSystemExceptions
{
    public class DataPresentException : Exception
    {
        public DataPresentException(string message):base(message)
        {
            ///////
        }
        public DataPresentException(string message, Exception inner)
          : base(message, inner)
        {
        }
    }
}
