using System;
using System.Collections.Generic;
using System.Text;

namespace Exigy.ErrorHandler
{
    public class MajorError : Exception
    {
        public MajorError(string message) : base(message)
        {

        }
    }
}
