using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppForms
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipcode)
        { 
        //Forming a url
        string key = "e707aad5de8d6b92c2ceab1bbf47ec65";

        //samples.openweathermap.org/data/2.5/forecast?id=845438&appid=b1b15e88fa797225412429c1c50c122a1
    //    api.openweathermap.org/data/2.5/weather?zip=560061,us&appid=e707aad5de8d6b92c2ceab1bbf47ec65


            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipcode + ",us&appid=" + key +"";
           
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if(results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
        }
    
}
