using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HEST_Cinema.ExceptionFolder
{
    public class GlobalException : Exception
    {
      public GlobalException(string message) : base(message)
      {
        
      }
    }
}
