using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHiWeather
{
    public partial class Form_main : Form
    {

        ArrayList weatherlist = new ArrayList();//장소에대한 리스트
        Days[] days = new Days[8];//장소에 대한 일별 세부사항 리스트
        Conditions[] hours = new Conditions[8];//장소에 대한 시간 세부사항 리스트
        public Form_main()
        {
            InitializeComponent();
            Load += Form_main_Load;
        }
        Panel panel;
        private void Form_main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(1000, 600);
            //this.BackColor = Color.AliceBlue;
            //==================================================
            //금천구 날씨추가
            days[0]=new Days(15, "부분적으로 맑음", 15,5);
            days[1] = new Days(16, "부분적으로 맑음", 13,-3);
            days[2] = new Days(17, "부분적으로 맑음", 10,-2);
            days[3] = new Days(18, "부분적으로 맑음", 12,3);
            days[4] = new Days(19, "맑음", 13,-1);
            days[5] = new Days(20, "대체로 흐림", 10,1);
            days[6] = new Days(21, "부분적으로 맑음", 10,-1);
            hours[0] = new Conditions(0, "대체로 흐림", 14, 0, 49, 2, "북서");
            hours[1] = new Conditions(3, "대체로 흐림", 14, 0, 53, 2, "북");
            hours[2] = new Conditions(6, "부분적으로 맑음", 14, 0, 47, 2, "북서");
            hours[3] = new Conditions(9, "부분적으로 맑음", 14, 0, 46, 2, "북서");
            hours[4] = new Conditions(12, "부분적으로 맑음", 14, 0, 43, 2, "북서");
            hours[5] = new Conditions(15, "부분적으로 맑음", 14, 0, 40, 2, "북");
            hours[6] = new Conditions(18, "대체로 흐림", 14, 0, 40, 2, "북동");
            hours[7] = new Conditions(21, "대체로 흐림", 14, 0, 42, 2, "북동");
            
            weatherlist.Add(new Weather("금천구", "서울특별시", days, hours));
            //==================================================

            //==================================================
            //관악구 날씨추가
            days[0] = new Days(15, "부분적으로 맑음", 15, 5);
            days[1] = new Days(16, "부분적으로 맑음", 13, -3);
            days[2] = new Days(17, "부분적으로 맑음", 10, -2);
            days[3] = new Days(18, "부분적으로 맑음", 12, 3);
            days[4] = new Days(19, "맑음", 13, -1);
            days[5] = new Days(20, "대체로 흐림", 10, 1);
            days[6] = new Days(21, "부분적으로 맑음", 10, -1);
            hours[0] = new Conditions(0, "대체로 흐림", 5, 0, 49, 2, "북서");
            hours[1] = new Conditions(3, "대체로 흐림", 7, 0, 53, 2, "북");
            hours[2] = new Conditions(6, "부분적으로 맑음", 8, 0, 47, 2, "북서");
            hours[3] = new Conditions(9, "부분적으로 맑음", 11, 0, 46, 2, "북서");
            hours[4] = new Conditions(12, "부분적으로 맑음", 14, 0, 43, 2, "북서");
            hours[5] = new Conditions(15, "부분적으로 맑음", 12, 0, 40, 2, "북");
            hours[6] = new Conditions(18, "대체로 흐림", 11, 0, 40, 2, "북동");
            hours[7] = new Conditions(21, "대체로 흐림", 8, 0, 42, 2, "북동");

            weatherlist.Add(new Weather("관악구", "서울특별시", days, hours));
            //==================================================

            panel = new Panel();
            panel.Size = new Size(1000, 600);
            panel.Location = new Point(0, 100);
            panel.BackColor = Color.AliceBlue;
            Controls.Add(panel);

            Drawclass d = new Drawclass();
            
            Button  button = d.btn1(new Btnclass(this, "btn1", "일기예보", 200, 100, 0, 0, btn_click));
            
            this.Controls.Add(button);
            this.Controls.Add(d.btn1(new Btnclass(this, "btn2", "즐겨찾기", 200, 100, 200, 0, btn_click)));
            this.Controls.Add(d.btn1(new Btnclass(this, "btn_feedback", "피드백", 60, 40, 800, 20, btn2_click)));
            this.Controls.Add(d.btn1(new Btnclass(this, "btn_setting", "설정", 60, 40, 900, 20, btn2_click)));
            
        }

        private void btn2_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            switch (button.Name)
            {
                
                case "btn_feedback"://피드백 버튼
                    //;
                    break;
                case "btn_setting"://설정 버튼
                    //Form_bookmark bookmark = new Form_bookmark();
                    //bookmark.FormBorderStyle = FormBorderStyle.None;
                    //bookmark.WindowState = FormWindowState.Normal;
                    //bookmark.Size = new Size(400,200);
                    //bookmark.ShowDialog();

                    Form_config config = new Form_config();
                    //config.Location=this.Location;
                    config.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        Form form = null;
        private void btn_click(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.Close();
                form = null;
            }

            Button button = (Button)sender;

            form = new Form();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.AliceBlue;

            switch (button.Name)
            {
                case "btn1"://일기예보 버튼
                    form.BackColor = Color.AliceBlue;
                    mainPrint();
                    break;
                case "btn2"://즐겨찾기 버튼
                    form.BackColor = Color.AliceBlue;
                    if (pn_create()) ;
                    //form.Controls.Add(pn_create());
                    break;
                default:
                    //form.BackColor = Color.Yellow;
                    break;
            }
            panel.Controls.Add(form);
            form.Show();
        }
        private void mainPrint()
        {
            Drawclass dc = new Drawclass();

            Lbclass lb1 = new Lbclass(this, "lb_day", "일일", 200, 40, 10, 200);
            Lbclass lb2 = new Lbclass(this, "lb_hour", "시간별", 200, 40, 10, 300);

            //form.Controls.Add(dc.lb1(lb1));
            //form.Controls.Add(dc.lb1(lb2));
        }
        private bool pn_create()
        {
            Panel p = new Panel();
            Label label = new Label();
            Label label1 = new Label();
            PictureBox weather = new PictureBox();
            PictureBox picture = new PictureBox();
            ((Weather)weatherlist[0]).Book = true;
            ((Weather)weatherlist[1]).Book = true;
            for (int a=0,i = 0, j = 0 ; a < weatherlist.Count; a++)
            {
                i = a % 2;
                
                if (((Weather)weatherlist[a]).Book)
                {
                    p.Name = "panel" + a+1;

                    p.Size = new Size(400, 120);
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Location = new Point(i * 500 + 10, j * 120 + 10);

                    label.Text = ((Weather)weatherlist[a]).Place + ", " + ((Weather)weatherlist[i]).City;
                    label.Location = new Point(120, 10);
                    label.Size = new Size(300, 30);
                    label.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);

                    label1.Text = (((Weather)weatherlist[a]).Conditions_hour[3].Temperature).ToString() + "˚C";
                    label1.Location = new Point(150, 50);
                    label1.Size = new Size(50, 20);
                    label1.Font = new Font(FontFamily.GenericSerif, 14.0F);

                    switch (((Weather)weatherlist[a]).Conditions_hour[3].Condition)
                    {
                        case "맑음":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("sunny");
                            break;
                        case "부분적으로 맑음":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("sunny");
                            break;
                        case "대체로 흐림":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("cloudy");
                            break;
                        case "비옴":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("rain");
                            break;
                    }
                    weather.SizeMode = PictureBoxSizeMode.StretchImage;
                    weather.Location = new Point(10, 10);
                    weather.Size = new Size(100, 100);

                    int dust = ((Weather)weatherlist[a]).Conditions_hour[3].Dust;
                    if (dust >= 0 && dust < 15)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust1");
                    }
                    else if (dust >= 15 && dust < 30)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust2");
                    }
                    else if (dust >= 30 && dust < 45)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust3");
                    }
                    else if (dust >= 45)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust4");
                    }
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    picture.Location = new Point(200, 45);
                    picture.Size = new Size(50, 50);


                    p.Controls.Add(label);
                    p.Controls.Add(label1);
                    p.Controls.Add(weather);
                    p.Controls.Add(picture);

                    form.Controls.Add(p);
                }
                if ((a % 2) == 1)
                {
                    j++;
                }
                
             }
            
           return true;
        }
    }
}
