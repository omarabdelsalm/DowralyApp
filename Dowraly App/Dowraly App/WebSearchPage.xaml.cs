﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcTron.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DowralyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebSearchPage : ContentPage
    {

        public WebSearchPage()
        {
            InitializeComponent();
            WebLab.Text = Lang.Resource.WebLab;
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
            
            Browser.Source = "https://www.google.com/android/find";
        }
    }
}