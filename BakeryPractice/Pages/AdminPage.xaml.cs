using BakeryPractice.ADOApp;
using System;
using System.Collections.Generic;
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

namespace BakeryPractice.Pages
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {

        public AdminPage()
        {
            InitializeComponent();
            materialListView.ItemsSource = App.Connection.Material.ToList();
            tbBalance.Text = App.Connection.Balance.FirstOrDefault().Summ.ToString();
            App.dispatcherTimer.Tick += new EventHandler((s, e) => materialListView.ItemsSource = App.Connection.Material.ToList());
        }

        private void BuyButtonClick(object sender, RoutedEventArgs e)
        {
            var boundData = (Material)((Button)sender).DataContext;

            boundData.Count++;

            App.Connection.Balance.FirstOrDefault().Summ -= boundData.Cost;

            App.Connection.SaveChanges();

            materialListView.ItemsSource = App.Connection.Material.ToList();
            tbBalance.Text = App.Connection.Balance.FirstOrDefault().Summ.ToString();


        }
    }
}
