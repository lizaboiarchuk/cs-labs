using System;

namespace PersonApp.Models
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _emailAddress;
        private DateTime _dateOfBirth;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value?.Trim();
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value?.Trim();
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value?.Trim();
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value.Date;
        }

        public bool IsAdult => CalculateAge() >= 18;

        public string SunSign
        {
            get => _sunSign;
            set => _sunSign = value?.Trim();
        }

        public string ChineseSign
        {
            get => _chineseSign;
            set => _chineseSign = value?.Trim();
        }

        public bool IsBirthday
        {
            get => _isBirthday;
            set => _isBirthday = value;
        }

        public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            DateOfBirth = dateOfBirth;
        }

        public Person(string firstName, string lastName, string emailAddress) : this(firstName, lastName, emailAddress, DateTime.MinValue)
        {
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth) : this(firstName, lastName, "", dateOfBirth)
        {
        }

        private int CalculateAge()
        {
            var age = DateTime.Today.Year - _dateOfBirth.Year;
            if (_dateOfBirth > DateTime.Today.AddYears(-age)) age--;
            return age;
        }

        public string CalculateSunSign()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Taurus";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Gemini";
            if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cancer";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Scorpio";
            if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagittarius";
            if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return "Capricorn";
            if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Aquarius";
            if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                return "Pisces";

            return string.Empty;
        }

        public string CalculateChineseSign()
        {
            int baseYear = 1900;
            int offset = DateOfBirth.Year - baseYear;
            int remainder = offset % 12;

            switch (remainder)
            {
                case 0: return "Rat";
                case 1: return "Ox";
                case 2: return "Tiger";
                case 3: return "Rabbit";
                case 4: return "Dragon";
                case 5: return "Snake";
                case 6: return "Horse";
                case 7: return "Goat";
                case 8: return "Monkey";
                case 9: return "Rooster";
                case 10: return "Dog";
                case 11: return "Pig";
                default: return string.Empty;
            }
        }
    }
}