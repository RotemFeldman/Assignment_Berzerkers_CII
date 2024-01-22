using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    public static class Weather
    {
        public enum WeatherEffect
        {
            None,Foggy,Stormy,Sunny
        }

        public static WeatherEffect CurrentWeather { get; private set; } = WeatherEffect.None;
        public static int WeatherLength { get; private set; }


        private static bool _changeweather;

        public void CheckWeather()
        {
            if(CurrentWeather == WeatherEffect.None) 
            {
                if (Random.Shared.NextDouble() > 0.5f)
                {
                    _changeweather = true;

                    WeatherLength = Random.Shared.Next(1, 5);
                }
            }
            else
            {
                WeatherLength--;
            }

            if(_changeweather)
            {
                CurrentWeather = (WeatherEffect)Random.Shared.Next(1,4);
            }


        }

    }
}
