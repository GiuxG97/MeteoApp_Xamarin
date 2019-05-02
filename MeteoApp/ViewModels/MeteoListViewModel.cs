using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MeteoApp
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Entry> _entries;

        public ObservableCollection<Entry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel()
        {
            Entries = new ObservableCollection<Entry>();

            /*for (var i = 0; i < 10; i++)
            {
                var e = new Entry
                {
                    ID = i,
                    Name = "Entry " + i,
                    Lat = i + 15,
                    Lon = i + 10
                };

                Entries.Add(e);
            }*/

            //Entries.Add(GpsAsync().Result);
            GpsAsync();

            // read from database
            List<Entry> locations = App.Database.GetLocationAsync().Result;
            foreach (var location in locations)
            {
                Entries.Add(location);
            }
        }

        public async System.Threading.Tasks.Task GpsAsync()
        {
            // geolocator
            var locator = CrossGeolocator.Current;
            Plugin.Geolocator.Abstractions.Position position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            Entry gps = await App.CityRequest.DoRequestLatLonAsync(position.Latitude, position.Longitude);

            Entries.Insert(0, gps);
        }
    }
}
