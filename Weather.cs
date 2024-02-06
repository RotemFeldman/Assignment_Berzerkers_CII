using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    public static class Weather
    {

        #region Const Strings 

        const string NONE_STAYS = "The weather is clear.";
        const string FOG_ANNOUNCMENT = "Heavy fog is setting in.";
        const string FOG_EFFECT = "Two succsesful rolls are now required to hit.";
        const string FOG_STAYS = "The fog lingers on.";
        const string STORM_ANNOUNCMENT = "A raging storm is rushing in!";
        const string STORM_EFFECT = "All dice modifiers are set to zero.";
        const string STORM_STAYS = "The heavy storm still rages.";
        const string SUNNY_ANNOUNCMENT = "A bright sun is rising over the horizon.";
        const string SUNNY_EFFECT = "All units are healed a small amount.";
        const string SUNNY_STAYS = "The sunshine is warm on the skin.";

        

        #endregion

        public enum WeatherEffect
        {
            None,Foggy,Stormy,Sunny
        }

        public static WeatherEffect CurrentWeather { get; private set; } = WeatherEffect.None;
        public static int WeatherLength { get; private set; }


        private static bool _changeweather;

        public static void CheckWeather()
        {
            Console.WriteLine("!!! WEATHER REPORT !!!");

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
                if (CurrentWeather == WeatherEffect.Sunny)
                {
                    SunnyEffect();
                }

                if (WeatherLength == 0)
                {                     
                    CurrentWeather = WeatherEffect.None;
                }
            }

            if (_changeweather)
            {
                CurrentWeather = (WeatherEffect)Random.Shared.Next(1, 4);

                switch (CurrentWeather)
                {
                    case WeatherEffect.Foggy:
                        Console.WriteLine(FOG_ANNOUNCMENT);
                        Console.WriteLine(FOG_EFFECT);
                        break;
                    case WeatherEffect.Stormy:
                        Console.WriteLine(STORM_ANNOUNCMENT);
                        Console.WriteLine(STORM_EFFECT);
                        StormyEffect();
                        
                        break;
                    case WeatherEffect.Sunny:
                        Console.WriteLine(SUNNY_ANNOUNCMENT);
                        Console.WriteLine(SUNNY_EFFECT);
                        break;

                }
            }
            else
            {
                switch (CurrentWeather)
                {
                    case WeatherEffect.None:
                        Console.WriteLine(NONE_STAYS);
                        break;
                    case WeatherEffect.Foggy:
                        Console.WriteLine(FOG_STAYS);
                        break;
                    case WeatherEffect.Stormy:
                        Console.WriteLine(STORM_STAYS);
                        break;
                    case WeatherEffect.Sunny:
                        Console.WriteLine(SUNNY_STAYS);
                        break;

                }
            }

            _changeweather = false;

            Console.WriteLine("!!! END OF REPORT !!!");
            Console.WriteLine();



        }

        

        static void SunnyEffect()
        {
            foreach (Unit u in UnitList.AllUnits)
            {
                u.Heal(Random.Shared.Next(5));
            }
        }

        static void StormyEffect()
        {
            foreach(Unit u in UnitList.AllUnits)
            {
                u.Attack(u);
            }
        }

    }
}
