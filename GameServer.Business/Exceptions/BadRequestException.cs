using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Business.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string massage) : base(massage)
        {
            
        }
    }
}
