using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Exceptions
{
    public class ClientSideException : Exception
    {
        public ClientSideException(string message):base(message)
        { 

        }
    }
}
