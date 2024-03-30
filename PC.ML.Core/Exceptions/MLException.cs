using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.ML.Core.Exceptions
{
    public class MLException : Exception
    {
        public MLException(string message) : base(message)
        {
        }
    }
}
