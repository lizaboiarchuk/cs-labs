using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PersonApp.Models;
using PersonApp.Exceptions;

namespace PersonApp.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        private ICommand _proceedCommand;

        public string FirstName
        {
            get => _person.FirstName;
            set
            {
                _person.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _person.LastName;
            set
            {
                _person.LastName = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => _person.EmailAddress;
            set
            {
                _person.EmailAddress = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                _person.DateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdult => _person.IsAdult;
        public string SunSign => _person.SunSign;
        public string ChineseSign => _person.ChineseSign;
        public bool IsBirthday => _person.IsBirthday;

        public ICommand ProceedCommand
        {
            get
            {
                if (_proceedCommand == null)
                {
                    _proceedCommand = new RelayCommand(async param => await ProceedAsync(), param => CanProceed());
                }
                return _proceedCommand;
            }
        }

        public PersonViewModel()
        {
            _person = new Person("", "", "");
            DateOfBirth = DateTime.Today;
        }

        private bool CanProceed()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                  !string.IsNullOrEmpty(LastName) &&
                  !string.IsNullOrEmpty(EmailAddress)
                  && DateOfBirth != default(DateTime);
        }

        private async Task ProceedAsync()
        {
            // Perform checks and calculations here
            if (!CanProceed())
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {

                if (DateOfBirth > DateTime.Now)
                {
                    throw new FutureDateException();
                }

                if (DateOfBirth < new DateTime(1900, 1, 1))
                {
                    throw new DistantPastDateException();
                }

                if (!IsValidEmail(EmailAddress))
                {
                    throw new InvalidEmailException();
                }

                // Calculate and set the SunSign and ChineseSign properties asynchronously
                _person.SunSign = await Task.Run(() => CalculateSunSign());
                _person.ChineseSign = await Task.Run(() => CalculateChineseSign());

                // Check if today is the person's birthday
                _person.IsBirthday = DateOfBirth.Day == DateTime.Today.Day && DateOfBirth.Month == DateTime.Today.Month;

                // Print the values of all 8 fields of the class
                MessageBox.Show($"First Name: {FirstName}\nLast Name: {LastName}\nEmail Address: {EmailAddress}\nDate of Birth: {DateOfBirth.ToShortDateString()}\nIs Adult: {IsAdult}\nSun Sign: {SunSign}\nChinese Sign: {ChineseSign}\nIs Birthday: {IsBirthday}");

            }
            catch (InvalidEmailException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (DistantPastDateException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FutureDateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private string CalculateSunSign()
        {
            return _person.CalculateSunSign();
        }

        private string CalculateChineseSign()
        {
            return _person.CalculateChineseSign();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}