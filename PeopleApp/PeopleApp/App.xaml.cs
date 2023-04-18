using System;
using System.Windows;

namespace PeopleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Console.WriteLine("hehehehe222");

            // Any custom startup logic goes here
        }
    }
}
