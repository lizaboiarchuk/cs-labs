using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace BirtdayApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        private string _ageText;
        public string AgeText
        {
            get => _ageText;
            set
            {
                _ageText = value;
                OnPropertyChanged();
            }
        }

        private string _birthdayMessage;
        public string BirthdayMessage
        {
            get => _birthdayMessage;
            set
            {
                _birthdayMessage = value;
                OnPropertyChanged();
            }
        }

        private string _westernZodiac;
        public string WesternZodiac
        {
            get => _westernZodiac;
            set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }

        private string _chineseZodiac;
        public string ChineseZodiac
        {
            get => _chineseZodiac;
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            DateOfBirth = DateTime.Today;
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void Calculate()
        {
            int age = CalculateAge();
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Invalid age. Please enter a valid date of birth.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AgeText = $"Your age is {age} years old.";

            CheckBirthday();

            WesternZodiac = CalculateWesternZodiac();
            ChineseZodiac = CalculateChineseZodiac();
        }

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }

        private void CheckBirthday()
        {
            DateTime today = DateTime.Today;
            if (DateOfBirth.Day == today.Day && DateOfBirth.Month == today.Month)
            {
                BirthdayMessage = "Happy Birthday!";
            }
            else
            {
                BirthdayMessage = "";
            }
        }

        private string CalculateWesternZodiac()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                return "Aries";
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                return "Taurus";
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                return "Gemini";
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                return "Cancer";
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                return "Leo";
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                return "Virgo";
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                return "Libra";
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                return "Scorpio";
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                return "Sagittarius";
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                return "Capricorn";
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                return "Aquarius";
            else
                return "Pisces";
        }

        private string CalculateChineseZodiac()
        {
            int year = DateOfBirth.Year;
            int chineseYear = year - 1900;
            int remainder = chineseYear % 12;

            switch (remainder)
            {
                case 0:
                    return "Rat";
                case 1:
                    return "Ox";
                case 2:
                    return "Tiger";
                case 3:
                    return "Rabbit";
                case 4:
                    return "Dragon";
                case 5:
                    return "Snake";
                case 6:
                    return "Horse";
                case 7:
                    return "Goat";
                case 8:
                    return "Monkey";
                case 9:
                    return "Rooster";
                case 10:
                    return "Dog";
                case 11:
                    return "Pig";
                default:
                    return "Unknown";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}