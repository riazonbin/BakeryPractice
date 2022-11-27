using BakeryPractice.Pages;
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
using BakeryPractice.ADOApp;

namespace BakeryPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartTimer();
            MainFrame.Navigate(new AuthorizationPage());
        }

        void StartTimer()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            foreach(var product in App.Connection.Product)
            {
                product.LeftTimeToLive--;
                if(product.LeftTimeToLive <= 0)
                {
                    App.Connection.Product.Remove(product);
                    App.Connection.SaveChanges();
                }
            }

            foreach(var recipe in App.Connection.Recipe) 
            {

                foreach(var material in recipe.RecipeMaterial)
                {
                    if(material.Material.Count <= 0)
                    {
                        break;
                    }

                    if(material == recipe.RecipeMaterial.Last())
                    {
                        Product newProduct = new Product
                        {
                            Name = recipe.Name,
                            LeftTimeToLive = recipe.TimeToLive,
                            Recipe = recipe,
                        };

                        foreach(var materialId in newProduct.Recipe.RecipeMaterial)
                        {
                            materialId.Material.Count--;
                        }

                        App.Connection.Product.Add(newProduct);
                    }
                }
            }
            App.Connection.SaveChanges();
        }
    }
}
