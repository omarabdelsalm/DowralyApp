using Firebase.Database;
using Firebase.Database.Query;
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
    public partial class PhonDataPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        FirebaseClient firebase = new FirebaseClient("https://dowralyapp-default-rtdb.firebaseio.com/");
        public PhonDataPage() 
        {
            InitializeComponent();
            this.bannerAd_view.AdsId = AdmobUnitIds.BannerId;
            MyImei.Text = Lang.Resource.MyImei;
            MyName.Text = Lang.Resource.MyName;

            MyPhon.Text = Lang.Resource.MyPhon;
            MyBtn.Text = Lang.Resource.MyBtn;

        }
        protected async override void OnAppearing()
        {


            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
            TxtMyImei.Completed += (object sender, EventArgs e) =>
            {
                _ = TxtMyName.Focus();
            };
            TxtMyName.Completed += (object sender, EventArgs e) =>
            {
                _ = TxtMyPhon.Focus();
            };
           
        }
        public async Task AddPerson(string Imeiy,string name, string MyPhon)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { Imei = Imeiy, Name = name, MyPhon = MyPhon });
        }
        private async void MyBtn_Clicked(object sender, EventArgs e)
        {
            if (TxtMyImei.Text != null && TxtMyName.Text != null && TxtMyPhon.Text != null)
            {
                await firebaseHelper.AddPerson(TxtMyImei.Text, TxtMyName.Text, TxtMyPhon.Text);
                TxtMyImei.Text = string.Empty;
                TxtMyName.Text = string.Empty;
                TxtMyPhon.Text = string.Empty;

                await DisplayAlert("Success", "تم اضافة البيانات", "OK");
            }
            else
            {
                await DisplayAlert("Success", "تاكد من ملء الحقول", "OK");

            }
            

            // var allPersons = await firebaseHelper.GetAllPersons();
            //lstPersons.ItemsSource = allPersons;
        }
    }
}