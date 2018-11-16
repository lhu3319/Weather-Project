using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsHiWeather
{
    class Conditions
    {
        int hour;
        string condition;//현재상태
        int temperature;//온도
        
        int humidity;//습도
        int dust;//미세먼지농도
        int windSpeed;//풍속
        string windDirection;//풍향


        //시간별 날씨 상태에 대해서 사용하는 생성자
        public Conditions(int hour,string condition, int temperature,int humidity,int dust,int windSpeed,string windDirection)
        {
            this.hour = hour;
            this.condition = condition;
            this.temperature = temperature;
            this.humidity = humidity;
            this.dust = dust;
            this.windSpeed = windSpeed;
            this.windDirection = windDirection;
        }

        public string Condition { get => condition; }
        public int Temperature { get => temperature; }
        public int Humidity { get => humidity; }
        public int Dust { get => dust; }
        public int WindSpeed { get => windSpeed; }
        public string WindDirection { get => windDirection; }
        public int Hour { get => hour; }
    }
}
