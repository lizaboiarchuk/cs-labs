using System;
using System.Windows;
using BirtdayApp.ViewModels;

namespace BirtdayApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
