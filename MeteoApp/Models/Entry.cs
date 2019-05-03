using MeteoApp.Utilities;
using System;
using Xamarin.Forms;

namespace MeteoApp
{
    public class Entry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public ImageSource Image { get; set; }
        public string Condition { get; set; }
    }
}
