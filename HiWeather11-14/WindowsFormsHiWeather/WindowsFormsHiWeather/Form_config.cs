using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace WindowsFormsHiWeather
{
    public partial class Form_config : Form
    {
        private Button btn;
        private RadioButton rdo;
        private TextBox text;
        private Panel panel_1;
        private Panel panel_2;
        private Panel panel_3;
        private Panel panel_4;
        private Panel panel_5;

        private int initchk = 0;


        TabControl tabcontrol;
        TabPage tabpage1;
        TabPage tabpage2;
        TextBox textbox_search;

        public Form_config()
        {
            InitializeComponent();
            Load += Form_config_Load;
        }



        private void Form_config_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;  // 상단표시줄 제거
            BackColor = Color.AliceBlue; // 폼 색상 변경

            SetRegion(); // 폼 둥글게 변경



            ArrayList arrList = new ArrayList();

            // Name , 가로시작 좌표, 세로시작 좌표, Text이름 
            arrList.Add(new Item("tabcontrol", 700, 370, "tabcontrol"));
            arrList.Add(new Item("tabpage1", 700, 150, "tabpage1"));
            arrList.Add(new Item("tabpage2", 700, 150, "tabpage2"));

            arrList.Add(new Item("label1", 90, 20, "label1")); // 상단제목 : 설정
            arrList.Add(new Item("label2", 20, 10, "label2")); // tabpage1 안에 : 테마
            arrList.Add(new Item("label3", 20, 120, "label3")); // tabpage1 안에 : 온도표시단위
            arrList.Add(new Item("label4", 20, 230, "label4")); // tabpage1 안에 : 시작위치
            arrList.Add(new Item("label5", 260, 20, "label5")); // tabpage2 안에 : 데이터 공급자
            arrList.Add(new Item("label6", 35, 100, "label6")); // tabpage2 안에 : 현재 기상 조건, 일간 일기 예보, 지도:
            arrList.Add(new Item("label7", 435, 100, "label7")); // tabpage2 안에 : 현재 상태 및 일간 예보제공:
            arrList.Add(new Item("label8", 455, 120, "label8")); // tabpage2 안에 : Total Weather Service Provider
            arrList.Add(new Item("label9", 20, 220, "label9")); // tabpage2 안에 : 정보
            arrList.Add(new Item("label10", 20, 250, "label10")); // tabpage2 안에 : Hi-Weather
            arrList.Add(new Item("label11", 20, 290, "label11")); // tabpage2 안에 : JSH corporation\r\n버전 4.26.12153.0

            arrList.Add(new Item("picturebox1", 60, 120, "picturebox1")); // tabpage2 안에 : picturebox1 : FORECA
            arrList.Add(new Item("picturebox2", 460, 150, "picturebox2")); // tabpage2 안에 : picturebox1 : Kweather
            arrList.Add(new Item("picturebox3", 50, 10, "picturebox3")); // default 폼 안에 : picturebox1 : config_image

            arrList.Add(new Item("panel_1", 20, 50, "panel_1")); // tabpage1 안에 : panel_1
            arrList.Add(new Item("panel_2", 20, 160, "panel_2")); // tabpage1 안에 : panel_2
            arrList.Add(new Item("panel_3", 20, 260, "panel_3")); // tabpage1 안에 : panel_3

            arrList.Add(new Item("radio1", 10, 10, "radio1")); // 25, 60, tabpage1 -> pannel1 안에 : 밝게
            arrList.Add(new Item("radio2", 10, 40, "radio2")); // 25, 90, tabpage1 -> pannel1 안에 : 어둡게
            arrList.Add(new Item("radio3", 10, 10, "radio3")); // 25, 170, tabpage1 -> pannel2 안에 : 섭씨
            arrList.Add(new Item("radio4", 10, 40, "radio4")); // 25, 200, tabpage1 -> pannel2 안에 : 화씨
            arrList.Add(new Item("radio5", 10, 10, "radio5")); // tabpage1 -> pannel3 안에 : 내 위치 항상검색
            arrList.Add(new Item("radio6", 10, 40, "radio6")); // tabpage1 -> pannel3 안에 : 기본 위치

            arrList.Add(new Item("search_button", 145, 295, "search_button")); // tabpage1 안에 : 검색 버튼
            arrList.Add(new Item("button_apply1", 460, 280, "button_apply1")); // tabpage1 안에 : 적용 버튼
            arrList.Add(new Item("button_cancel1", 570, 280, "button_cancel1")); // tabpage1 안에 : 취소 버튼
            arrList.Add(new Item("button_apply2", 460, 280, "button_apply2")); // tabpage1 안에 : 적용 버튼
            arrList.Add(new Item("button_cancel2", 570, 280, "button_cancel2")); // tabpage1 안에 : 취소 버튼

            arrList.Add(new Item("textbox_search", 170, 295, "textbox_search")); // tabpage1 안에 : 검색 TextBox 


            // ArrayList 안에 정의된 컨트롤 생성 부분
            for (int i = 0; i < arrList.Count; i++)
            {
                Control_Create((Item)arrList[i]);
            }

        }

        private void Control_Create(Item item)
        {
            switch (item.getType())
            {

                case "tabcontrol":
                    tabcontrol = new TabControl();  // 탭 컨트롤 생성
                    tabcontrol.Location = new System.Drawing.Point(50, 50); // TabControl 시작 위치 지정
                    tabcontrol.Size = new Size(item.getX(), item.getY()); //  TabControl 사이즈 크기 지정.
                    tabcontrol.SelectedIndex = 0;
                    tabcontrol.TabIndex = 0;
                    tabcontrol.Name = item.getTxt();
                    tabcontrol.Text = "탭컨트롤";
                    tabcontrol.ItemSize = new Size(30, 30);

                    Controls.Add(tabcontrol);

                    break;
                case "tabpage1":
                    tabpage1 = new TabPage();  // 탭페이지1 생성
                    tabpage1.Size = new Size(256, 214);  // (256, 214) TabPage 사이즈 크기 지정.
                    tabpage1.TabIndex = 0;
                    tabpage1.Name = item.getTxt();
                    tabpage1.Text = "                                      일반                                        ";
                    tabpage1.BackColor = Color.AliceBlue;
                    tabcontrol.Controls.Add(tabpage1);
                    break;
                case "tabpage2":
                    tabpage2 = new TabPage();  // 탭페이지1 생성
                    tabpage2.Size = new Size(256, 214);  // (256, 214) TabPage 사이즈 크기 지정.
                    tabpage2.TabIndex = 0;
                    tabcontrol.Name = item.getTxt();
                    tabpage2.Text = "                                      정보                                        ";
                    tabpage2.BackColor = Color.AliceBlue;
                    tabcontrol.Controls.Add(tabpage2);
                    break;
                case "panel_1":
                    panel_1 = new Panel();  // 패널 컨트롤 생성
                    panel_1.Location = new Point(item.getX(), item.getY());
                    panel_1.Size = new Size(100, 100);
                    panel_1.BorderStyle = BorderStyle.None;
                    tabpage1.Controls.Add(panel_1);
                    break;
                case "panel_2":
                    panel_2 = new Panel();  // 패널 컨트롤 생성
                    panel_2.Location = new Point(item.getX(), item.getY());
                    panel_2.Size = new Size(100, 70);
                    panel_2.BorderStyle = BorderStyle.None;
                    //panel_2.BackColor = Color.DimGray;
                    tabpage1.Controls.Add(panel_2);
                    break;
                case "panel_3":
                    panel_3 = new Panel();  // 패널 컨트롤 생성
                    panel_3.Location = new Point(item.getX(), item.getY());
                    panel_3.Size = new Size(120, 70);
                    panel_3.BorderStyle = BorderStyle.None;
                    //panel_3.BackColor = Color.DimGray;
                    tabpage1.Controls.Add(panel_3);
                    break;
                case "label1":
                    Label label1 = new Label();
                    label1.Size = new Size(100, 30);  // label1 사이즈 설정 
                    label1.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label1.Name = item.getTxt();
                    label1.Text = "설정";
                    label1.Font = new Font(FontFamily.GenericSansSerif, 15.0F, FontStyle.Bold); // : 설정
                    Controls.Add(label1);
                    break;
                case "label2":
                    Label label2 = new Label();
                    label2.Size = new Size(100, 30);  // label2 사이즈 설정 
                    label2.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label2.Name = item.getTxt();
                    label2.Text = "테마";
                    label2.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 테마
                    tabpage1.Controls.Add(label2);
                    break;
                case "label3":
                    Label label3 = new Label();
                    label3.Size = new Size(150, 30);  // label3 사이즈 설정 
                    label3.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label3.Name = item.getTxt();
                    label3.Text = "온도표시단위";
                    label3.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 온도표시단위 
                    tabpage1.Controls.Add(label3);
                    break;
                case "label4":
                    Label label4 = new Label();
                    label4.Size = new Size(150, 30);  // label4 사이즈 설정 
                    label4.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label4.Name = item.getTxt();
                    label4.Text = "시작 위치";
                    label4.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 시작 위치
                    tabpage1.Controls.Add(label4);
                    break;
                case "label5":
                    Label label5 = new Label();
                    label5.Size = new Size(150, 30);  // label5 사이즈 설정 
                    label5.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label5.Name = item.getTxt();
                    label5.Text = "데이터 공급자";
                    label5.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 데이터 공급자
                    tabpage2.Controls.Add(label5);
                    break;
                case "label6":
                    Label label6 = new Label();
                    label6.Size = new Size(210, 12);  // label5 사이즈 설정 
                    label6.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label6.Name = item.getTxt();
                    label6.Text = "현재 기상 조건, 일간 일기 예보, 지도:";
                    //label6.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 현재 기상 조건, 일간 일기 예보, 지도:
                    tabpage2.Controls.Add(label6);
                    break;
                case "label7":
                    Label label7 = new Label();
                    label7.Size = new Size(210, 12);  // label5 사이즈 설정 
                    label7.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label7.Name = item.getTxt();
                    label7.Text = "현재 상태 및 일간 예보제공:";
                    //label6.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 현재 상태 및 일간 예보제공:
                    tabpage2.Controls.Add(label7);
                    break;
                case "label8":
                    Label label8 = new Label();
                    label8.Size = new Size(220, 15);  // label5 사이즈 설정 
                    label8.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label8.Name = item.getTxt();
                    label8.Text = "Total Weather Service Provider";
                    label8.Font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold); // : Total Weather Service Provider
                    tabpage2.Controls.Add(label8);
                    break;
                case "label9":
                    Label label9 = new Label();
                    label9.Size = new Size(210, 30);  // label9 사이즈 설정 
                    label9.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label9.Name = item.getTxt();
                    label9.Text = "정보";
                    label9.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 정보
                    tabpage2.Controls.Add(label9);
                    break;
                case "label10":
                    Label label10 = new Label();
                    label10.Size = new Size(210, 30);  // label10 사이즈 설정 
                    label10.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label10.Name = item.getTxt();
                    label10.Text = "Hi-Weather";
                    label10.Font = new Font(FontFamily.GenericSansSerif, 15.0F, FontStyle.Regular); // : Hi-Weather
                    tabpage2.Controls.Add(label10);
                    break;
                case "label11":
                    Label label11 = new Label();
                    label11.Size = new Size(210, 30);  // label10 사이즈 설정 
                    label11.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label11.Name = item.getTxt();
                    label11.Text = "JSH corporation\r\n버전 4.26.12153.0";
                    label11.Font = new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Italic); // : Hi-Weather
                    tabpage2.Controls.Add(label11);
                    break;
                case "radio1":
                    RadioButton radio1 = new RadioButton();
                    radio1.Size = new Size(100, 15);  // radio1 버튼 사이즈
                    radio1.Location = new Point(item.getX(), item.getY());
                    radio1.Name = item.getTxt();
                    radio1.Text = "밝게";
                    radio1.Checked = true;
                    radio1.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold);
                    panel_1.Controls.Add(radio1);
                    //tabpage1.Controls.Add(radio1);
                    break;
                case "radio2":
                    RadioButton radio2 = new RadioButton();
                    radio2.Size = new Size(100, 15);  // radio2 버튼 사이즈
                    radio2.Location = new Point(item.getX(), item.getY());
                    radio2.Name = item.getTxt();
                    radio2.Text = "어둡게";
                    radio2.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold);
                    panel_1.Controls.Add(radio2);
                    //tabpage1.Controls.Add(radio2);
                    break;
                case "radio3":
                    RadioButton radio3 = new RadioButton();
                    radio3.Size = new Size(100, 15);  // radio3 버튼 사이즈
                    radio3.Location = new Point(item.getX(), item.getY());
                    radio3.Name = item.getTxt();
                    radio3.Text = "섭씨";
                    radio3.Checked = true;
                    radio3.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 섭씨
                    panel_2.Controls.Add(radio3);
                    break;
                case "radio4":
                    RadioButton radio4 = new RadioButton();
                    radio4.Size = new Size(100, 15);  // radio4 버튼 사이즈
                    radio4.Location = new Point(item.getX(), item.getY());
                    radio4.Name = item.getTxt();
                    radio4.Text = "화씨";
                    radio4.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 화씨
                    panel_2.Controls.Add(radio4);
                    break;
                case "radio5":
                    RadioButton radio5 = new RadioButton();
                    radio5.Size = new Size(115, 15);  // radio5 버튼 사이즈
                    radio5.Location = new Point(item.getX(), item.getY());
                    radio5.Name = item.getTxt();
                    radio5.Text = "내 위치 항상검색";
                    radio5.Checked = true;
                    radio5.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 내 위치 항상검색
                    panel_3.Controls.Add(radio5);
                    break;
                case "radio6":
                    RadioButton radio6 = new RadioButton();
                    radio6.Size = new Size(75, 15);  // radio6 버튼 사이즈
                    radio6.Location = new Point(item.getX(), item.getY());
                    radio6.Name = item.getTxt();
                    radio6.Text = "기본 위치";
                    radio6.Click += radio_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 기본 위치
                    panel_3.Controls.Add(radio6);
                    break;

                case "picturebox1":
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox1.Location = new System.Drawing.Point(item.getX(), item.getY());
                    Image picturebox1_myImage = global::WindowsFormsHiWeather.Properties.Resources.FORECA;  // (Image)Properties.Resources.ResourceManager.GetObject("FORECA.png");
                    picturebox1.ClientSize = new Size(130, 40);
                    picturebox1.Image = (Image)picturebox1_myImage;
                    picturebox1.Name = item.getTxt();
                    tabpage2.Controls.Add(picturebox1);
                    break;
                case "picturebox2":
                    PictureBox picturebox2 = new PictureBox();
                    picturebox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox2.Location = new System.Drawing.Point(item.getX(), item.getY());
                    Image picturebox2_myImage = global::WindowsFormsHiWeather.Properties.Resources.Kweather;  // (Image)Properties.Resources.ResourceManager.GetObject("FORECA.png");
                    picturebox2.ClientSize = new Size(130, 40);
                    picturebox2.Image = (Image)picturebox2_myImage;
                    picturebox2.Name = item.getTxt();
                    tabpage2.Controls.Add(picturebox2);
                    break;
                case "picturebox3":
                    PictureBox picturebox3 = new PictureBox();
                    picturebox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox3.Location = new Point(item.getX(), item.getY());
                    Image picturebox3_myImage = global::WindowsFormsHiWeather.Properties.Resources.config_image;  // (Image)Properties.Resources.ResourceManager.GetObject("FORECA.png");
                    picturebox3.ClientSize = new Size(40, 40);
                    picturebox3.Image = (Image)picturebox3_myImage;
                    picturebox3.Name = item.getTxt();
                    Controls.Add(picturebox3);
                    break;

                case "search_button":
                    Button search_button = new Button();
                    search_button.DialogResult = DialogResult.OK;
                    search_button.Cursor = Cursors.Hand;
                    search_button.Click += btn_click;

                    //System.Drawing.Image myImage = Image.FromFile (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Image.gif");
                    Image search_button_myImage = (Image)Properties.Resources.ResourceManager.GetObject("search_button");

                    ImageList imageList1 = new ImageList();
                    //imageList1.Images.Add(Image.FromFile("C:\\search_button.bmp"));

                    imageList1.ImageSize = new Size(255, 255);
                    imageList1.Images.Add(search_button_myImage);
                    imageList1.ImageSize = new Size(40, 28);
                    imageList1.TransparentColor = Color.Transparent;

                    search_button.ImageIndex = 0;
                    search_button.ImageList = imageList1;
                    //btn.Image = Image.FromFile();
                    // Align the image and text on the button.
                    //btn.ImageAlign = ContentAlignment.MiddleRight;
                    //btn.TextAlign = ContentAlignment.MiddleCenter;
                    //btn.BackgroundImageLayout = ImageLayout.Zoom;  // 테스트중

                    // Give the button a flat appearance.
                    search_button.TabStop = false;
                    search_button.FlatStyle = FlatStyle.Flat;
                    search_button.FlatAppearance.BorderSize = 0;

                    search_button.Size = new Size(23, 23);  // (23, 23) 사이즈 설정
                    search_button.Location = new Point(item.getX(), item.getY());  // 위치지정

                    search_button.Name = item.getTxt();
                    search_button.Text = "";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 내 위치 항상검색
                    tabpage1.Controls.Add(search_button);
                    break;

                case "button_apply1":
                    Button button_apply1 = new Button();
                    button_apply1.DialogResult = DialogResult.OK;
                    button_apply1.Cursor = Cursors.Hand;
                    button_apply1.Click += btn_click;
                    button_apply1.Size = new Size(100, 30);  // 사이즈 설정
                    button_apply1.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_apply1.Name = item.getTxt();
                    button_apply1.Text = "적용";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage1 적용버튼
                    tabpage1.Controls.Add(button_apply1);
                    break;

                case "button_cancel1":
                    Button button_cancel1 = new Button();
                    button_cancel1.DialogResult = DialogResult.OK;
                    button_cancel1.Cursor = Cursors.Hand;
                    button_cancel1.Click += btn_click;
                    button_cancel1.Size = new Size(100, 30);  // 사이즈 설정
                    button_cancel1.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_cancel1.Name = item.getTxt();
                    button_cancel1.Text = "취소";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage1 취소버튼
                    tabpage1.Controls.Add(button_cancel1);
                    break;
                case "button_apply2":
                    Button button_apply2 = new Button();
                    button_apply2.DialogResult = DialogResult.OK;
                    button_apply2.Cursor = Cursors.Hand;
                    button_apply2.Click += btn_click;
                    button_apply2.Size = new Size(100, 30);  // 사이즈 설정
                    button_apply2.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_apply2.Name = item.getTxt();
                    button_apply2.Text = "적용";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage2 적용버튼
                    tabpage2.Controls.Add(button_apply2);
                    break;
                case "button_cancel2":
                    Button button_cancel2 = new Button();
                    button_cancel2.DialogResult = DialogResult.OK;
                    button_cancel2.Cursor = Cursors.Hand;
                    button_cancel2.Click += btn_click;
                    button_cancel2.Size = new Size(100, 30);  // 사이즈 설정
                    button_cancel2.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_cancel2.Name = item.getTxt();
                    button_cancel2.Text = "취소";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage2 취소버튼
                    tabpage2.Controls.Add(button_cancel2);
                    break;
                case "textbox_search":
                    textbox_search = new TextBox();
                    textbox_search.AcceptsReturn = true;
                    textbox_search.AcceptsTab = true;
                    textbox_search.Size = new Size(100, 30);  // 사이즈 설정
                    textbox_search.Location = new Point(item.getX(), item.getY());  // 위치지정
                    textbox_search.Name = item.getTxt();
                    textbox_search.Text = "지역명 검색";
                    textbox_search.ReadOnly = true;
                    textbox_search.Click += textbox_search_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 검색 TextBox 
                    tabpage1.Controls.Add(textbox_search);

                    break;


                default:
                    break;
            }

        }



        private void btn_click(object o, EventArgs a)
        {
            string names = "";
            foreach (Control ct in Controls)
            {
                // names += ct.Name + " ";
                //if(ct.Name != "btn_3")
                //{
                ct.BackColor = Color.Silver;
                //}                
            }
            // 생성한 버튼 연결
            btn = (Button)o;

            if (btn.Name == "button_cancel1" || btn.Name == "button_cancel2")
            {
                this.Close();
            }
            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }

        private void radio_click(object o, EventArgs a)
        {
            // 생성한 Radio버튼 연결
            rdo = (RadioButton)o;

            if (rdo.Name == "radio6")
            {
                textbox_search.ReadOnly = false;
            }
            else
            {
                textbox_search.ReadOnly = true;
            }
            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }

        private void textbox_search_click(object o, EventArgs a)
        {
            // 생성한 Radio버튼 연결
            text = (TextBox)o;

            if (text.Name == "textbox_search" && initchk == 0 && textbox_search.ReadOnly == false)
            {
                textbox_search.Text = "";
                initchk = 1;
            }

            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }


        private void SetRegion()
        {
            Rectangle rectangle = this.DisplayRectangle;
            GraphicsPath path = new GraphicsPath();
            int arcRadius = 50;
            path.AddArc(rectangle.X + 16, rectangle.Y + 4, arcRadius, arcRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - arcRadius - 6, rectangle.Y + 4, arcRadius, arcRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - arcRadius - 6, rectangle.Y + rectangle.Height - arcRadius - 18, arcRadius, arcRadius, 0, 90);
            path.AddArc(rectangle.X + 16, rectangle.Y + rectangle.Height - arcRadius - 18, arcRadius, arcRadius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }

    }

}

public class Item
{
    private string type;
    private int x;
    private int y;
    private string txt;
    public Item(string type, int x, int y, string txt)
    {
        this.type = type;
        this.x = x;
        this.y = y;
        this.txt = txt;

    }
    public string getType()
    {
        return type;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public string getTxt()
    {
        return txt;
    }
}

