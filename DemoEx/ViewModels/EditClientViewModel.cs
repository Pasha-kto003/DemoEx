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
    public class EditClientViewModel : BaseNotify
    {
        Some_DbEntities db;
        Client client;
        Gender gender;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public char GenderCode { get; set; }
        public Gender SelectedGender { get => gender; set { gender = value; OnPropertyChanged(); } }
        public ObservableCollection<Gender> Genders { get; set; }
        public RelayCommand SaveClient { get; set; }


        public EditClientViewModel(MainViewModel mainVM, Client client)
        {
            db = DB.GetDB();
            Genders = new ObservableCollection<Gender>(db.Gender);
            this.client = client;
            FirstName = client.FirstName;
            LastName = client.LastName;
            Patronymic = client.Patronymic;
            Birthday = (DateTime)client.Birthday;
            Phone = client.Phone;
            Email = client.Email;
            RegistrationDate = DateTime.Now;
            SelectedGender = client.Gender;

            SaveClient = new RelayCommand(() =>
            {
                db = DB.GetDB();
                client.FirstName = FirstName;
                client.LastName = LastName;
                client.Patronymic = Patronymic;
                client.Phone = Phone;
                client.Email = Email;
                client.Birthday = Birthday.Date;
                client.Gender = SelectedGender;
                client.RegistrationDate = RegistrationDate;
                mainVM.CurrentView = new ClientListPage(mainVM);
                db.SaveChanged();
            });
        }
    
    
    }
}
