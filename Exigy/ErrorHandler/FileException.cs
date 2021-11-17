using System;
using System.Collections.Generic;
using System.Text;

namespace Exigy.ErrorHandler
{
    public class FileException : Exception
    {
        public FileException(string message) : base(message)
        {

        }
    }
}
