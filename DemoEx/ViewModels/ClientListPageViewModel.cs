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
    public class ClientListPageViewModel : BaseNotify
    {
        DB db;
        Some_DbEntities dbEntities;
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Patronymic { get; set; }
        //public DateTime Birthday { get; set; } 
        //public DateTime RegistrationDate { get; set; }
        //public long Phone { get; set; }
        //public string Email { get; set; }
        //public char GenderCode { get; set; }
        Client client;
        ClientService clientService;
        public ObservableCollection<Client> Clients { get; set; }
        public Client SelectedClient { get => client; set { client = value; OnPropertyChanged(); } }
        public RelayCommand AddNewClient { get; set; }
        public RelayCommand EditClient { get; set; }

        public ClientListPageViewModel(MainViewModel mainVM)
        {
            dbEntities = DB.GetDB();
            Clients = new ObservableCollection<Client>(dbEntities.Client);
            AddNewClient = new RelayCommand(() =>
            {
                mainVM.CurrentView = new AddClientView(mainVM);
            });

        }
    }
}
