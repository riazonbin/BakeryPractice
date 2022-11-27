using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
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

namespace BakeryPractice.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthorizationButtonClick(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text != "" && tbPassword.Text != "")
            {
                var dataLogin = App.Connection.User.FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == tbPassword.Text);
                if(dataLogin is null)
                {
                    MessageBox.Show("No such user!");
                    return;
                }

                if(dataLogin.Role_Id == 1)
                {
                    NavigationService.Navigate(new AdminPage());
                }
                else
                {
                    NavigationService.Navigate(new CashierPage());
                }
            }
        }
    }
}
