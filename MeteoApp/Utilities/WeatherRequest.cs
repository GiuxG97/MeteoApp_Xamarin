using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Net.Http;

namespace MeteoApp.Utilities
{
    class WeatherRequest
    {

        public WeatherRequest()
        {
            Request = "http://api.openweathermap.org/data/2.5/weather?";
            Key = "&APPID=c200173e4aeed3198803206f96382afe";
        }

        public async Task<Entry> DoRequestAsync(string cityName)
        {
            var httpClient = new HttpClient();
            //TODO: prendere la città dal db attraverso cityName
            var lat = 45.81082;
            var lon = 9.086044;
            var uri = Request + "lat=" + lat + "&lon=" + lon + Key; 
            var contentResponse = await httpClient.GetStringAsync(uri);
            var weather = JObject.Parse(contentResponse)["weather"][0];

            Entry entry = new Entry
            {
                
            };


            return null;

        }

        public string Request { get; set; }
        public string Key { get; set; }
    }

    

}
