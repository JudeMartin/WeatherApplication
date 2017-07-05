using System; 

namespace WeatherFormsApplication.Model
{
    public class WeatherObservation
    {
        public string WeatherCondition { get; set; }
        public string ICAO { get; set; }
        public long Elevation { get; set; }
        public string CountryCode { get; set; }
        public string CloudCode { get; set; }
        public long Lon { get; set; }
        public long  Temperature { get; set; }
        public long DewPoint { get; set; }
        public long WindSpeed { get; set; }
        public long Humidity { get; set; }
        public string StationName { get; set; }
        public DateTime Date { get; set; }
        public long Lat { get; set; }
        public long HectoPascAltimeter { get; set; }
    }
}
