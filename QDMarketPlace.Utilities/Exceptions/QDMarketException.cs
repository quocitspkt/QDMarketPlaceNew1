using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Utilities.Exceptions
{
    public class QDMarketException : Exception
    {
        public QDMarketException()
        {
        }

        public QDMarketException(string message)
            : base(message)
        {
        }

        public QDMarketException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
