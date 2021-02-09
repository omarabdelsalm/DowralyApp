using DowralyApp;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dowraly_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;

            ReData.Text = DowralyApp.Lang.Resource.ReData;
            SeData.Text = DowralyApp.Lang.Resource.SeData;
            WebSearch.Text = DowralyApp.Lang.Resource.WebSearch;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new PhonDataPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new SearchPage());
        }
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new WebSearchPage());
        }
    }
}
