using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Data;
using System.Windows.Input;
using PeopleApp.Models;
using PeopleApp.ViewModels;

namespace PeopleApp.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged("SelectedPerson");
            }
        }

        public ICommand AddPersonCommand { get; set; }
        public ICommand EditPersonCommand { get; set; }
        public ICommand DeletePersonCommand { get; set; }
        public ICommand SaveDataCommand { get; set; }

        public ICollectionView PersonsView { get; }

        public PersonViewModel()
        {
            // Load users from file or create default users
            LoadUsers();

            PersonsView = CollectionViewSource.GetDefaultView(Persons);
            PersonsView.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Ascending));

            AddPersonCommand = new RelayCommand(AddPerson);
            EditPersonCommand = new RelayCommand(EditPerson, CanExecuteEditOrDelete);
            DeletePersonCommand = new RelayCommand(DeletePerson, CanExecuteEditOrDelete);
            SaveDataCommand = new RelayCommand(SaveData);
        }

        private void LoadUsers()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.dat");
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Persons = (ObservableCollection<Person>) formatter.Deserialize(fs);
                }
            }
            else
            {
                
                Persons = GenerateDefaultUsers(50);
                SaveData(Persons);
                Console.WriteLine("hehehehe");
            }
        }

        private ObservableCollection<Person> GenerateDefaultUsers(int count)
        {
            ObservableCollection<Person> users = new ObservableCollection<Person>();

            for (int i = 0; i < count; i++)
            {
                users.Add(new Person
                {
                    Id = i + 1,
                    FirstName = $"FirstName{i + 1}",
                    LastName = $"LastName{i + 1}",
                    DateOfBirth = DateTime.Now.AddYears(-(i % 100)).AddDays(i),
                    AgeText = $"AgeText{i + 1}",
                    BirthdayMessage = $"BirthdayMessage{i + 1}",
                    WesternZodiac = $"WesternZodiac{i % 12 + 1}",
                    ChineseZodiac = $"ChineseZodiac{i % 12 + 1}"
                });
            }

            return users;
        }

        private void SaveData(object parameter)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.dat");
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, Persons);
            }
        }

        private void AddPerson(object parameter)
        {
            Person newPerson = new Person
            {
                Id = Persons.Count + 1,
                FirstName = "New",
                LastName = "User",
                DateOfBirth = DateTime.Today
            };
            Persons.Add(newPerson);
            SelectedPerson = newPerson;
        }

        private void EditPerson(object parameter)
        {
            // You may want to implement a way to edit the person through a dialog
            // or another interface, depending on your application's requirements.
            // For now, we'll just change the first name for demonstration purposes.
            if (SelectedPerson != null)
            {
                SelectedPerson.FirstName = "Edited";
            }
        }

        private void DeletePerson(object parameter)
        {
            if (SelectedPerson != null) {
                Persons.Remove(SelectedPerson);
            }
        }

        private bool CanExecuteEditOrDelete(object parameter)
        {
            return SelectedPerson != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

