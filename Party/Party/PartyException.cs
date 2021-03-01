using System;

namespace Party
{
    public class PartyException : Exception
    {
        #region Constructor

        public PartyException(string message) : base(message)
        {
            Console.WriteLine("Party exception: " + message);
        }

        #endregion
    }
}
