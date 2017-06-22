using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinProjMVC.Exceptions
{
    public class DuplicateMessageException : Exception
    {
        public DuplicateMessageException()
        {

        }

        public DuplicateMessageException(string message)
            : base(message)
        {
            
        }

        public DuplicateMessageException(string message, Exception inner):
            base(message)
        {

        }
    }
}