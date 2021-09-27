using DemoEx.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            //Some_DbEntities some_DbEntities = new Some_DbEntities();

            //var rows = File.ReadAllLines(@"C:\Users\user\Desktop\ДЭ1135\Сессия 1\service_a_import.txt");
            //for(int i = 1; i < rows.Length; i++)
            //{
            //    var cols = rows[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    var time = cols[1].Trim().Split();
            //    int second = int.Parse(time[0]);
            //    if(time[1] == "мин.")
            //        second *= 60;
            //    else if(time[1] == "час.")
            //        second *= 3600;
            //    Service service = new Service
            //    {
            //        Cost = decimal.Parse(cols[2]),
            //        Title = cols[0],
            //        Discount = double.Parse(cols[3]),
            //        DurationInSeconds = second
            //    };

            //    some_DbEntities.Service.Add(service);


            //}
            //some_DbEntities.SaveChanges();

            ////var clients = some_DbEntities.Client.ToList();
            ////var services = some_DbEntities.Service.ToList();
            ////var rows = File.ReadAllLines(@"C:\Users\user\Desktop\ДЭ1135\Сессия 1\clientservice_a_import.csv");
            ////for (int i = 1; i < rows.Length; i++)
            ////{
            ////    var cols = rows[i].Split(new char[] { ';' });
            ////    var client = clients.FirstOrDefault(c => c.LastName == cols[0]);
            ////    var service = services.FirstOrDefault(c => c.Title == cols[2]);
            ////    var time = DateTime.Parse(cols[1]);
            ////    ClientService clientService = new ClientService
            ////    {
            ////        Client = client,
            ////        Service = service,
            ////        StartTime = time
            ////    };
            ////    some_DbEntities.ClientService.Add(clientService);
            ////}
            ////some_DbEntities.SaveChanges();
            
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
