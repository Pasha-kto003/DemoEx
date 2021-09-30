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
    public class AddServiceViewModel : BaseNotify
    {
        Some_DbEntities db;
        Service service;
        public string Title { get; set; }
        public Decimal Cost { get; set; }
        public int DurationInSeconds { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }

        public RelayCommand SaveService { get; set; }
        public RelayCommand Back { get; set; }

        public Service SelectedService { get => service; set { service = value; OnPropertyChanged(); } }
        
        public ObservableCollection<Service> Services { get; set; }

        public void AddService(string title, decimal cost, int duration, string description, float discount)
        {
            db = DB.GetDB();
            Service service = new Service
            {
                Title = title,
                Cost = cost,
                DurationInSeconds = duration,
                Description = description,
                Discount = discount
            };
            db.Service.Add(service);
            db.SaveChanges();
        }
        public AddServiceViewModel(MainViewModel mainVM)
        {
            db = DB.GetDB();

            SaveService = new RelayCommand(() =>
            {
                AddService(Title, Cost, DurationInSeconds, Description, Discount);
            });
            Back = new RelayCommand(() =>
            {
                mainVM.CurrentView = new ServiceListPage(mainVM);
            });
        }
    }
}
