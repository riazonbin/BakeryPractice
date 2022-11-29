using BakeryPractice.ADOApp;
using MaterialDesignColors.Recommended;
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
    /// Interaction logic for CashierPage.xaml
    /// </summary>
    public partial class CashierPage : Page
    {
        public CashierPage()
        {
            InitializeComponent();
            lvProducts.ItemsSource = App.Connection.Product.ToList();

            App.dispatcherTimer.Tick += new EventHandler((s, e) => lvProducts.ItemsSource = App.Connection.Product.ToList());
        }

        private void SellButtonClick(object sender, RoutedEventArgs e)
        {
            var boundData = (Product)((Button)sender).DataContext;

            App.Connection.Balance.FirstOrDefault().Summ += (decimal)boundData.TotalCost;

            App.Connection.Sale.Add(new Sale
            {
                Cost = (decimal)boundData.TotalCost,
                Date = DateTime.Now,
                Recipe = boundData.Recipe,
                User = App.currentUser
            });


            App.Connection.Product.Remove(boundData);
            App.Connection.SaveChanges();

            lvProducts.ItemsSource = App.Connection.Product.ToList();
        }

        private void leftTimeBarLoaded(object sender, RoutedEventArgs e)
        {
            var boundData = (Product)((ProgressBar)sender).DataContext;
            ProgressBar bar = ((ProgressBar)sender);

            if (boundData.LeftTimeToLive >= boundData.Recipe.TimeToLive * 0.70)
            {
                bar.Foreground = Brushes.Green;
            }
            else if (boundData.LeftTimeToLive >= boundData.Recipe.TimeToLive * 0.40)
            {
                bar.Foreground = Brushes.Yellow;
            }
            else
            {
                bar.Foreground = Brushes.Red;
            }
        }
    }
}
