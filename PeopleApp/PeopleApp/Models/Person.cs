using System;

namespace PeopleApp.Models
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AgeText { get; set; }
        public string BirthdayMessage { get; set; }
        public string WesternZodiac { get; set; }
        public string ChineseZodiac { get; set; }
    }
}
