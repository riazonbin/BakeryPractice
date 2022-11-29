using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using BakeryPractice.ADOApp;

namespace BakeryPractice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static BakeryPracticeEntities Connection = new BakeryPracticeEntities();
        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public static User currentUser= null;
    }
}
