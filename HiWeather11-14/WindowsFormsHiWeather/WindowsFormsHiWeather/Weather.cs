using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsHiWeather
{
    class Weather
    {
        string place;//장소
        string city;
        Days[] days_day;//날짜
        Conditions[] conditions_hour;//시간
        bool book;
        public Weather(string place,string city , Days[] days_day, Conditions[] conditions_hour)
        {
            this.place = place;
            this.city = city;
            this.days_day = days_day;
            this.conditions_hour = conditions_hour;
            book = false;
        }

        public string Place { get => place; }
        public string City { get => city; }
        public bool Book { get => book; set => book = value; }
        internal Days[] Days_day { get => days_day; }
        internal Conditions[] Conditions_hour { get => conditions_hour; }
    }
}
