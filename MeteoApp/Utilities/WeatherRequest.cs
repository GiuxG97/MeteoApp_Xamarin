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
            var uri = Request + "lat=" + entryParam.Lat + "&lon=" + entryParam.Lon + Key;
            System.Diagnostics.Debug.WriteLine("URI: "+uri);

            var contentResponse = await httpClient.GetStringAsync(uri);
            
            var condition = (string)JObject.Parse(contentResponse)["weather"][0]["description"];
            var max = (double)JObject.Parse(contentResponse)["main"]["temp_max"];
            var min = (double)JObject.Parse(contentResponse)["main"]["temp_min"];

            string iconName = (string)JObject.Parse(contentResponse)["weather"][0]["icon"];

            // image request
            var urlImage = "http://openweathermap.org/img/w/" + iconName + ".png";
            //var image = await httpClient.GetByteArrayAsync(urlImage);

            ImageSource image = ImageSource.FromUri(new Uri(urlImage));

            Entry entry = new Entry
            {
                Name = entryParam.Name,
                Lat = entryParam.Lat,
                Lon = entryParam.Lon,
                Condition = condition,
                MaxTemperature = max,
                MinTemperature = min,
                Image = image
            };
            
            return entry;

        }

        public string Request { get; set; }
        public string Key { get; set; }
    }

    

}
