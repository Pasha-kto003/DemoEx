using DemoEx.Core;
using DemoEx.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DemoEx.ViewModels
{
    public class ClientListPageViewModel : BaseNotify
    {
        public ComboBoxItem SelectedType { get; set; }

        DB db;
        Some_DbEntities dbEntities;
        string selectedType;
        Client client;
        public List<string> Types { get; set; }
        public RelayCommand SearchGender { get; set; }

        ClientService clientService;
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Gender> Genders { get; set; }
       
        public Client SelectedClient { get => client; set { client = value; OnPropertyChanged(); } }
        public string SelectedGender { get => selectedType; set { selectedType = value; OnPropertyChanged(); } }
        private readonly CollectionViewSource _FilterClients = new CollectionViewSource();

        public ICollectionView FilterClients => _FilterClients?.View;

        private void OnClientFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Client client))
            { e.Accepted = false; return; }
            var filter_text = _ClientFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;
            if (client.FirstName is null || client.LastName is null || client.Patronymic is null || client.Email is null || client.Phone is null)
            { e.Accepted = false; return; }

            if ((string)SelectedType.Tag == "0")
                if (client.FirstName.Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "1")
                if (client.LastName.Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "2")
                if (client.Patronymic.Contains(filter_text  )) return;
            if ((string)SelectedType.Tag == "3")
                if (client.Email.ToString().Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "4")
                if (client.Phone.ToString().Contains(filter_text)) return;
            e.Accepted = false;
        }

        private string _ClientFilterText;
        public string ClientFilterText
        {
            get => _ClientFilterText;
            set
            {
                if (SelectedType == null)
                {
                    MessageBox.Show("Выберите тип поиска!");
                    return;
                }
                if (!Set(ref _ClientFilterText, value)) return;
                _FilterClients.View.Refresh();
                //Search();
            }
        }
        public RelayCommand AddNewClient { get; set; }
        public RelayCommand EditClient { get; set; }

        public ClientListPageViewModel(MainViewModel mainVM)
        {
            dbEntities = DB.GetDB();
            //Types = new List<string>()
            //{
            //    "По мужскому полу",
            //    "По женскому полу"
            //};
            Clients = new ObservableCollection<Client>(dbEntities.Client);
            _FilterClients.Source = Clients;
            _FilterClients.Filter += OnClientFiltred;

            AddNewClient = new RelayCommand(() =>
            {
                mainVM.CurrentView = new AddClientView(mainVM);
            });
            EditClient = new RelayCommand(() =>
            {
                mainVM.CurrentView = new EditClient(mainVM, SelectedClient);
            });
            //SearchGender = new RelayCommand(() =>
            //{
            //    dbEntities = DB.GetDB();
            //    List<Gender> genders = new List<Gender>();
            //    switch (SelectedGender)
            //    {
            //        case "По мужскому полу":
            //            foreach (Gender gender in Genders)
            //            {
            //                if (gender.Code.Contains("м"))
            //                    genders.Add(gender);
            //            }
            //            break;

            //        case "По женскому полу":
            //            foreach (Gender gender in Genders)
            //            {
            //                if (gender.Code.Contains("ж"))
            //                {
            //                    genders.Add(gender);
            //                }
            //            }
            //            break;
            //    }
            //});
        }
        
    }
}
