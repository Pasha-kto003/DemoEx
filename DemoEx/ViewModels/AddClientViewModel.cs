using DemoEx.Core;
using DemoEx.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEx.ViewModels
{
    public class AddClientViewModel : BaseNotify
    {
        Some_DbEntities db;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        //public DateTime RegistrationDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public char GenderCode { get; set; }
        Client client;
        Gender gender;
        public RelayCommand SaveClient { get; set; }
        public RelayCommand Back { get; set; }
        public Client SelectedClient { get => client; set { client = value; OnPropertyChanged(); } }
        public Gender SelectedGender { get => gender; set { gender = value; OnPropertyChanged(); } }
        public ObservableCollection<Gender> Genders { get; set; }
        public void AddClient(string fname, string lname, string patronymic, DateTime birthday, string phone, string email, char genderCode)
        {
            db = DB.GetDB();
            Client client = new Client
            {
                FirstName = fname,
                LastName = lname,
                Patronymic = patronymic,
                Birthday = birthday,
                Phone = phone,
                Email = email,
                GenderCode = genderCode.ToString()
            };

            db.Client.Add(client);
            db.SaveChanges();
        }

        public AddClientViewModel(MainViewModel mainVM)
        {
            db = DB.GetDB();
            Genders = new ObservableCollection<Gender>(db.Gender);
            
            SaveClient = new RelayCommand(() =>
            {
                AddClient(FirstName, LastName, Patronymic, Birthday, Phone, Email, GenderCode);
                mainVM.CurrentView = new ClientListPage(mainVM);
            });
            Back = new RelayCommand(() =>
            {
                mainVM.CurrentView = new ClientListPage(mainVM);
            });
        }
    }
}
