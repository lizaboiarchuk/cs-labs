using System;

namespace PeopleApp.Models
{
    public class PersonAppException : Exception
    {
        public PersonAppException(string message) : base(message) { }
    }
}
