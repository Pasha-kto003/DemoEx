using DemoEx.Core;
using DemoEx.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoEx.ViewModels
{
    public class MainViewModel : BaseNotify
    {
        public RelayCommand OpenClientList { get; set; }
        public RelayCommand OpenServiceList { get; set; }
        public RelayCommand OpenClientServiceList { get; set; }
        private Page _currentView;

        public Page CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged("CurrentView"); }
        }
        public MainViewModel()
        {
            OpenClientList = new RelayCommand(() =>
            {
                CurrentView = new ClientListPage(this);
            });
        }
    }
}
