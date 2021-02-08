using Firebase.Database;
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
    public partial class SearchPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://dowralyapp-default-rtdb.firebaseio.com/");
        public SearchPage()
        {
            InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
            BtnSerch.Text =Lang.Resource.BtnSerch;
            MyImei.Text = Lang.Resource.MyImei;
            MyName.Text = Lang.Resource.MyName;

            MyPhon.Text = Lang.Resource.MyPhon;
        
        }

        //private async void RetEntry()
        //{
        //    var person = await firebaseHelper.GetPerson(SrBar.Text.ToString());
        //    if (person != null)
        //    //if (txtId.Text == (long)Entry) { }
        //    {
        //        MyImei.Text = person.Imei;
        //        MyName.Text = person.Name;
        //        MyPhon.Text = person.MyPhon;

        //        await DisplayAlert("Success", "تم استعادة البانات", "OK");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Success", "لا يوجد اعضاء لهذا الرقم التسلسلي", "OK");
        //    }
        //}

        private async void RetEntry(object sender, EventArgs e)
        {
            var person = await firebaseHelper.GetPerson(SrBar.Text.ToString());
            if (person != null)
            //if (txtId.Text == (long)Entry) { }
            {
                TxtMyImei.Text = person.Imei;
                TxtMyName.Text = person.Name;
                TxtMyPhon.Text = person.MyPhon;

                await DisplayAlert("تم", "نعم يوجد جهاز مفقود", "OK");

            }
            else
            {
                await DisplayAlert("Success", "لا يوجد جهاز بهذا الرقم", "OK");
            }
        }
    }
}