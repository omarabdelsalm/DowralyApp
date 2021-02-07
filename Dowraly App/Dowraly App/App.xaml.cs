using DowralyApp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dowraly_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PhonDataPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
