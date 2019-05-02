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
    public class WeatherRequest
    {

        public WeatherRequest()
        {
            Request = "http://api.openweathermap.org/data/2.5/weather?";
            Key = "&units=metric&APPID=c200173e4aeed3198803206f96382afe";
        }

        public async Task<Entry> DoRequestAsync(Entry entryParam)
        {
            var httpClient = new HttpClient();
            //TODO: prendere la città dal db attraverso cityName
            /*var lat = 45.81082;
            var lon = 9.086044;*/
            var uri = Request + "lat=" + entryParam.Lat + "&lon=" + entryParam.Lon + Key; 
            //var uri = Request + "q=" + cityName + Key;
            System.Diagnostics.Debug.WriteLine("URI: "+uri);

            var contentResponse = await httpClient.GetStringAsync(uri);
            //var weather = JObject.Parse(contentResponse)["weather"][0];  
            
            var condition = (string)JObject.Parse(contentResponse)["weather"][0]["description"];
            //var temp = JObject.Parse(contentResponse)["main"]["temp"];
            var max = (double)JObject.Parse(contentResponse)["main"]["temp_max"];
            var min = (double)JObject.Parse(contentResponse)["main"]["temp_min"];

            Entry entry = new Entry
            {
                Name = entryParam.Name,
                Lat = entryParam.Lat,
                Lon = entryParam.Lon,
                Condition = condition,
                MaxTemperature = max,
                MinTemperature = min
            };


            return entry;

        }

        public string Request { get; set; }
        public string Key { get; set; }
    }

    

}
