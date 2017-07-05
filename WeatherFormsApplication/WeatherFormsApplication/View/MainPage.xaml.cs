using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFormsApplication.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherFormsApplication.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage()
        {
            vm = new MainPageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            var Longitude = double.Parse(Lon.Text);
            var Latitude = double.Parse(Lat.Text);
            var url = string.Format("http://api.geonames.org/findNearByWeatherJSON?lat={0}&lng={1}&username={2}", Latitude,Longitude, "mjude");
			await vm.GetWeatherAsync(url);
		} 
    }
}
