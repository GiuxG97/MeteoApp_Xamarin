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
            Key = "&APPID=c200173e4aeed3198803206f96382afe";
        }

        public async Task<Entry> DoRequestAsync(Entry entry)
        {
            var httpClient = new HttpClient();
            //TODO: prendere la città dal db attraverso cityName
            var lat = entry.Lat;
            var lon = entry.Lon;
            var uri = Request + "lat=" + lat + "&lon=" + lon + Key;
            var contentResponse = await httpClient.GetStringAsync(uri);
            var weather = JObject.Parse(contentResponse)["weather"][0];
            var main = JObject.Parse(contentResponse)["main"];

            var image = (string)weather["icon"];
            var description = (string)weather["description"];
            var temp = (double)main["tem"];
            var tempMax = (double)main["temp_max"];
            var tempMin = (double)main["temp_min"];

            Entry entryWeather = new Entry
            {
                ID = entry.ID,
                Lat = lat,
                Lon = lon,
                Name = entry.Name,
                Image = image,
                Condition = description,
                Temperature = temp,
                MaxTemperature = tempMax,
                MinTemperature = tempMin
                
            };

            return entryWeather;
        }

        public string Key { get; set; }
        public string Request { get; set; }
    }
}
