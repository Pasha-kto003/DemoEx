using DemoEx.Core;
using DemoEx.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DemoEx.ViewModels
{
    public class ServiceListPageViewModel : BaseNotify
    {
        DB db;
        Some_DbEntities dbEntities;
        string selectedType;
        Service service;
        public List<string> Types { get; set; }
        public ComboBoxItem SelectedType { get; set; }
        
        public ObservableCollection<Service> Services { get; set; }

        public Service SelectedService { get => service; set { service = value; OnPropertyChanged(); } }
        private readonly CollectionViewSource _FilterService = new CollectionViewSource();

        public ICollectionView FilterClients => _FilterService?.View;

        private void OnServiceFiltred(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Client client))
            { e.Accepted = false; return; }
            var filter_text = _ServiceFilterText;
            if (string.IsNullOrWhiteSpace(filter_text)) return;
            if (service.Title is null || service.Description is null || service.Cost.ToString() is null || service.DurationInSeconds.ToString() is null || service.Discount is null)
            { e.Accepted = false; return; }

            if ((string)SelectedType.Tag == "0")
                if (service.Title.Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "1")
                if (service.Cost.ToString().Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "2")
                if (service.Description.Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "3")
                if (service.Discount.ToString().Contains(filter_text)) return;
            if ((string)SelectedType.Tag == "4")
                if (service.DurationInSeconds.ToString().Contains(filter_text)) return;
            e.Accepted = false;
        }

        private string _ServiceFilterText;
        public string ServiceFilterText
        {
            get => _ServiceFilterText;
            set
            {
                if (SelectedType == null)
                {
                    MessageBox.Show("Выберите тип поиска!");
                    return;
                }
                if (!Set(ref _ServiceFilterText, value)) return;
                _FilterService.View.Refresh();
                //Search();
            }
        }
        public RelayCommand AddNewService { get; set; }
        public RelayCommand EditService { get; set; }

        public ServiceListPageViewModel(MainViewModel mainVM)
        {
            dbEntities = DB.GetDB();
            Services = new ObservableCollection<Service>(dbEntities.Service);
            _FilterService.Source = Services;
            _FilterService.Filter += OnServiceFiltred;

            AddNewService = new RelayCommand(() =>
            {
                mainVM.CurrentView = new AddServiceView(mainVM);
            });
            EditService = new RelayCommand(() =>
            {
                mainVM.CurrentView = new EditServiceView(mainVM, SelectedService);
            });
        }
    }
}
