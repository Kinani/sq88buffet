using SQ88Buffet.Models;
using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SQ88Buffet
{
    public partial class App : Application
    {
        public static List<Purchase> GlobalPurhases;
        public App()
        {
            InitializeComponent();
            GlobalPurhases = new List<Purchase>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
