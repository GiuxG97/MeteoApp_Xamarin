using System;

namespace MeteoApp
{
    public class Location
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public string Image { get; set; }
    }
}
