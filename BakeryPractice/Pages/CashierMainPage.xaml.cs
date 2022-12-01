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
    /// Interaction logic for CashierMainPage.xaml
    /// </summary>
    public partial class CashierMainPage : Page
    {
        public CashierMainPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Переход на страницу с отчётами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportPageButtonClick(object sender, RoutedEventArgs e)
        {
            CashierFrame.Navigate(new ReportPage());
        }


        /// <summary>
        /// Переход на страницу продаж
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CashierPageButtonClick(object sender, RoutedEventArgs e)
        {
            CashierFrame.Navigate(new CashierPage());
        }
    }
}
