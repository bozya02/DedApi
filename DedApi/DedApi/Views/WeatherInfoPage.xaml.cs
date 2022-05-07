using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DedApi.Model;
using Xamarin.Forms.Maps;

namespace DedApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherInfoPage : ContentPage
    {
        public WeatherModel Weather { get; set; }
        public WeatherInfoPage()
        {
            InitializeComponent();

            Weather = new WeatherModel();
            this.BindingContext = Weather;
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var cityName = searchBar.Text;
            Weather = await App.RequestManager.GetWeather(cityName);

            map.MoveToRegion(MapSpan.FromCenterAndRadius(Weather.Position, Distance.FromKilometers(50)));

            map.ItemsSource = new List<WeatherModel>
            {
                new WeatherModel
                {
                    Name = Weather.Name,
                    Coord = new Coord
                    {
                        Lat = Weather.Coord.Lat,
                        Lon = Weather.Coord.Lon,
                    },
                    Sys = new Sys
                    {
                        Country = Weather.Sys.Country
                    }
                }
            };
            this.BindingContext = Weather;
        }
    }
}