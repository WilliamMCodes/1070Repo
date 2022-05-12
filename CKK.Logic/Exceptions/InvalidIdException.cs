using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Exceptions
{
    class InvalidIdException : Exception
    {
        public override string Message { get; }
        public InvalidIdException(int id)
        {
            Message = $"{id} is not a valid I.D. number.";
        }
    }
}
