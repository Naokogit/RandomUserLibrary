using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace RandomUserLibrary
{
    public class RandomUser
    {
        /// <summary>
        /// Permette di ottenere la Root della stringa Json ottenuta tramite https://randouser.me/api 
        /// tramite una richiesta asincrona
        /// </summary>
        /// <param name="n">Numero di richieste da fare (Di default impostate ad 1)</param>
        /// <returns>Root Object</returns>
        public async Task<RootObject> GetUsersAsync(int n = 1)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.randomuser.me");
            HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/?results=" + n);
            response.EnsureSuccessStatusCode();

            var stringResult = await response.Content.ReadAsStringAsync();
            RootObject root = JsonConvert.DeserializeObject<RootObject>(stringResult);
            return root;
        }


        public class Name
        {
            public string title { get; set; }
            public string first { get; set; }
            public string last { get; set; }
        }

        public class Coordinates
        {
            public string latitude { get; set; }
            public string longitude { get; set; }
        }

        public class Timezone
        {
            public string offset { get; set; }
            public string description { get; set; }
        }

        public class Location
        {
            public Street street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
            public Coordinates coordinates { get; set; }
            public Timezone timezone { get; set; }
        }
        public class Street
        {
            public int number { get; set; }
            public string name { get; set; }
        }

        public class Login
        {
            public string uuid { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string salt { get; set; }
            public string md5 { get; set; }
            public string sha1 { get; set; }
            public string sha256 { get; set; }
        }

        public class Dob
        {
            public DateTime date { get; set; }
            public int age { get; set; }
        }

        public class Registered
        {
            public DateTime date { get; set; }
            public int age { get; set; }
        }

        public class Id
        {
            public string name { get; set; }
            public object value { get; set; }
        }

        public class Picture
        {
            public string large { get; set; }
            public string medium { get; set; }
            public string thumbnail { get; set; }
        }

        public class Result
        {
            public string gender { get; set; }
            public Name name { get; set; }
            public Location location { get; set; }
            public string email { get; set; }
            public Login login { get; set; }
            public Dob dob { get; set; }
            public Registered registered { get; set; }
            public string phone { get; set; }
            public string cell { get; set; }
            public Id id { get; set; }
            public Picture picture { get; set; }
            public string nat { get; set; }
        }

        public class Info
        {
            public string seed { get; set; }
            public int results { get; set; }
            public int page { get; set; }
            public string version { get; set; }
        }

        public class RootObject
        {
            public List<Result> results { get; set; }
            public Info info { get; set; }
        }
    }
}
