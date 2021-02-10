using DowralyApp;
using MarcTron.Plugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Dowraly_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
            ReData.Text = DowralyApp.Lang.Resource.ReData;
            SeData.Text = DowralyApp.Lang.Resource.SeData;
            WebSearch.Text = DowralyApp.Lang.Resource.WebSearch;
            ImeSearch.Text = DowralyApp.Lang.Resource.ImeSearch;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new PhonDataPage());
            }
            else
            {
                await DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
                return;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new SearchPage());
            }
            else
            {
                await DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
                return;
            }

        }
        private async void Button_Clicked_2(object sender, EventArgs e)
        {
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.Internet)
                {
                    CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.InterstitialId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new WebSearchPage());
            }
            else
            {
                await DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
                return;
            }
        }

        private async void ImeSearch_Clicked(object sender, EventArgs e)
        {
                    var current = Connectivity.NetworkAccess;
                    if (current == NetworkAccess.Internet)
                    {
                        CrossMTAdmob.Current.LoadInterstitial(AdmobUnitIds.RewardedId);
            CrossMTAdmob.Current.ShowInterstitial();
            await Navigation.PushAsync(new ImeiInfoPage());
            }
            else
            {
                await DisplayAlert("انتباه", "الرجاء الاتصال بالانترنت", "ok");
                return;
            }
        }
    }
}
