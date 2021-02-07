using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowralyApp
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://dowralyapp-default-rtdb.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Name = item.Object.Name,
                  Imei = item.Object.Imei,
                  MyPhon = item.Object.MyPhon,
                  //PointNum1 = item.Object.PointNum1,
                  //PointNum2 = item.Object.PointNum2,
                  //PhNum = item.Object.PhNum
              }).ToList();
        }
        public async Task AddPerson(string Imeiy, string name, string MyPhon)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { Imei = Imeiy, Name = name, MyPhon = MyPhon });
        }

        public async Task<Person> GetPerson(string Imeiy)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Imei == Imeiy).FirstOrDefault();
        }

        public async Task UpdatePerson(string name, string Imeiy, string MyPhon)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Imei == Imeiy).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { Imei = Imeiy, Name = name, MyPhon = MyPhon });
        }
            public async Task DeletePerson(string Imei)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.Imei == Imei).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
