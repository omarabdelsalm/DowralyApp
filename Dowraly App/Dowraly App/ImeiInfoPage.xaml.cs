using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DowralyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImeiInfoPage : ContentPage
    {
        public ImeiInfoPage()
        {
            InitializeComponent();
            ImwiLab.Text = Lang.Resource.ImwiLab;
            this.bannerAd_view2.AdsId = AdmobUnitIds.BannerId;
            Browser.Source = "https://www.imei.info/";
        }
    }
}