using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherAppForms;

namespace WeatherAppForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();

            this.Title = "Weather App";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;




        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if(zipCodeEntry.Text != null)
            {
                Weather weather = await Core.GetWeather(zipCodeEntry.Text);
                this.BindingContext = weather;
                getWeatherBtn.Text = "Search Again";
            }
            else
            {
                
            }
        }
    }
}