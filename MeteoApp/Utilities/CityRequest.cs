using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Net.Http;
using MeteoApp.Models;

namespace MeteoApp.Utilities
{
    public class CityRequest
    {
        
        public CityRequest()
        {
            Request = "https://api.opencagedata.com/geocode/v1/json?q=";
            Key = "&key=ea341c0e70344a13bc96f6c28727735a";
        }

        public async Task<Entry> DoRequestAsync(string cityName)
        {
            var httpClient = new HttpClient();
            var contentResponse = await httpClient.GetStringAsync((Request + cityName + Key));
            
            var geometry = JObject.Parse(contentResponse)["results"][0]["geometry"];
            var name = (string)JObject.Parse(contentResponse)["results"][0]["formatted"];
            var lat = (double)geometry["lat"];
            var lon = (double)geometry["lng"];
            
            Entry entry = new Entry
            {
                Lon = lon,
                Lat = lat,
                Name = name
            };

            // save it in database
            await App.Database.SaveLocationAsync(entry);

            return entry;
        }

        public string Key { get; set; }
        public string Request { get; set; }
    }
}
