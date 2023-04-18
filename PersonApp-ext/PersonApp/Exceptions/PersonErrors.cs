using System;

namespace PersonApp.Exceptions
{
    public class FutureDateException : Exception
    {
        public FutureDateException()
            : base("Date of birth cannot be in the future.")
        {
        }
    }

    public class DistantPastDateException : Exception
    {
        public DistantPastDateException()
            : base("Date of birth is too far in the past.")
        {
        }
    }

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Invalid email address.")
        {
        }
    }
}