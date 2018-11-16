using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsHiWeather
{
    class Days
    {
        int day;
        string condition;//현재상태
        int toptemperature;//최고온도
        int bottomtemperature;//최저온도

        //일별 날씨 상태에 대해서 사용하는 생성자
        public Days(int day, string condition, int toptemperature,int bottomtemperature)
        {
            this.day = day;
            this.condition = condition;
            this.toptemperature = toptemperature;
            this.bottomtemperature = bottomtemperature;
        }

        public int Day { get => day; }
        public string Condition { get => condition; }
        public int Toptemperature { get => toptemperature; }
        public int Bottomtemperature { get => bottomtemperature; }
    }
}
