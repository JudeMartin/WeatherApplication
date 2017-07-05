using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherFormsApplication.Model;

namespace WeatherFormsApplication.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string Station;
        public string StationName
        {
            get { return Station; }
            set
            {
                Station = value;
                NotifyPropertyChanged();

            }
        }

        private long El;
        public long Elevation
        {
            get { return El; }
            set
            {
                El = value;
                NotifyPropertyChanged();

            }
        }

        private long Temp;
        public long Temperature
        {
            get { return Temp; }
            set
            {
                Temp = value;
                NotifyPropertyChanged();

            }
        }

        private long Humid;
        public long Humidity
        {
            get { return Humid; }
            set
            {
                Humid = value;
                NotifyPropertyChanged();

            }
        }

        public async Task GetWeatherAsync(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var JSONResult = response.Content.ReadAsStringAsync().Result;
            var weather = JsonConvert.DeserializeObject<WeatherResult>(JSONResult);
            SetValues(weather);
        }

        private void SetValues(WeatherResult weather)
        {
            var stationName = weather.WeatherObservation.StationName;
            var elevation = weather.WeatherObservation.Elevation;
            var temperature = weather.WeatherObservation.Temperature;
            var humidity = weather.WeatherObservation.Humidity;
            StationName = stationName;
            Elevation = elevation;
            Temperature = temperature;
            Humidity = humidity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


    }
}
