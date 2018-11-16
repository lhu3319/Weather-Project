using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHiWeather
{
    public partial class Form_Feedback : Form
    {
        TextBox textbox_emailadress;
        TextBox textbox_content;
        Button button_send;
        Button button_cancel;
        private TextBox text;
        private Button btn;

        private int emailclick_initchk = 0;
        private int contentclick_initchk = 0;

        public Form_Feedback()
        {
            InitializeComponent();
            Load += Form_Feedback_Load;
        }

        private void Form_Feedback_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;  // 상단표시줄 제거
            BackColor = Color.AliceBlue; // 폼 색상 변경

            SetRegion(); // 폼 둥글게 변경            


            ArrayList arrList = new ArrayList();

            arrList.Add(new Item("combobox1", 200, 120, "combobox1"));
            arrList.Add(new Item("label1", 50, 30, "label1")); // 상단제목 라벨 : FeedBack
            arrList.Add(new Item("label2", 50, 113, "label2")); // 라벨 : 문의종류
            arrList.Add(new Item("label3", 29, 170, "label3")); // 라벨 : 이메일 주소
            arrList.Add(new Item("label4", 57, 230, "label4")); // 라벨 : 질문내용

            arrList.Add(new Item("button_send", 670, 280, "button_send")); // 버튼 : 보내기
            arrList.Add(new Item("button_cancel", 670, 340, "button_cancel")); // 버튼 : 취소

            arrList.Add(new Item("textbox_emailadress", 200, 175, "textbox_emailadress")); // 이메일 주소 TextBox
            arrList.Add(new Item("textbox_content", 200, 237, "textbox_content")); // 내용입력 TextBox

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
                case "combobox1":
                    ComboBox combobox1 = new ComboBox();

                    combobox1.Name = item.getTxt();
                    combobox1.Items.Add("첫번째 문의항목");
                    combobox1.Items.Add("두번째 문의항목");
                    combobox1.Items.Add("세번째 문의항목");
                    combobox1.Items.Add("네번째.....");
                    combobox1.Items.Add("직접입력");
                    combobox1.Location = new Point(item.getX(), item.getY());
                    combobox1.Size = new Size(450, 100);
                    Controls.Add(combobox1);
                    break;
                case "label1":
                    Label label1 = new Label();
                    label1.Size = new Size(220, 42);  // label1 사이즈 설정 
                    label1.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label1.Name = item.getTxt();
                    label1.Text = "FeedBack";
                    label1.Font = new Font(FontFamily.GenericSansSerif, 30.0F, FontStyle.Bold); // : FeedBack
                    Controls.Add(label1);
                    break;
                case "label2":
                    Label label2 = new Label();
                    label2.Size = new Size(200, 32);  // label2 사이즈 설정 
                    label2.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label2.Name = item.getTxt();
                    label2.Text = "문의 종류  :";
                    label2.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 문의종류
                    Controls.Add(label2);
                    break;
                case "label3":
                    Label label3 = new Label();
                    label3.Size = new Size(160, 32);  // label3 사이즈 설정 
                    label3.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label3.Name = item.getTxt();
                    label3.Text = "이메일 주소  :";
                    label3.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 이메일 주소
                    Controls.Add(label3);
                    break;
                case "label4":
                    Label label4 = new Label();
                    label4.Size = new Size(130, 32);  // label4 사이즈 설정 
                    label4.Location = new Point(item.getX(), item.getY());  // 위치지정
                    label4.Name = item.getTxt();
                    label4.Text = "질문내용  :";
                    label4.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 질문내용
                    Controls.Add(label4);
                    break;
                case "textbox_emailadress":
                    textbox_emailadress = new TextBox();
                    textbox_emailadress.AcceptsReturn = true;
                    textbox_emailadress.AcceptsTab = true;
                    textbox_emailadress.Size = new Size(450, 30);  // 사이즈 설정
                    textbox_emailadress.Location = new Point(item.getX(), item.getY());  // 위치지정
                    textbox_emailadress.Name = item.getTxt();
                    textbox_emailadress.Text = "                                Sample@naver.com";
                    textbox_emailadress.Click += textbox_emailadress_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 검색 TextBox 
                    Controls.Add(textbox_emailadress);
                    break;
                case "textbox_content":
                    textbox_content = new TextBox();
                    textbox_content.AcceptsReturn = true;
                    textbox_content.AcceptsTab = true;
                    textbox_content.Multiline = true;
                    textbox_content.Size = new Size(450, 175);  // 사이즈 설정
                    textbox_content.Location = new Point(item.getX(), item.getY());  // 위치지정
                    textbox_content.Name = item.getTxt();
                    textbox_content.Text = "내용입력";
                    textbox_content.Click += textbox_content_click;
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : 검색 TextBox 
                    Controls.Add(textbox_content);
                    break;
                case "button_send":
                    button_send = new Button();
                    button_send.DialogResult = DialogResult.OK;
                    button_send.Cursor = Cursors.Hand;
                    button_send.Click += button_send_click;
                    button_send.Size = new Size(100, 50);  // 사이즈 설정
                    button_send.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_send.Name = item.getTxt();
                    button_send.Text = "보내기";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage1 적용버튼
                    Controls.Add(button_send);
                    break;
                case "button_cancel":
                    button_cancel = new Button();
                    button_cancel.DialogResult = DialogResult.OK;
                    button_cancel.Cursor = Cursors.Hand;
                    button_cancel.Click += button_send_click;
                    button_cancel.Size = new Size(100, 50);  // 사이즈 설정
                    button_cancel.Location = new Point(item.getX(), item.getY());  // 위치지정

                    button_cancel.Name = item.getTxt();
                    button_cancel.Text = "취소";
                    //radio1.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold); // : tappage1 적용버튼
                    Controls.Add(button_cancel);
                    break;

                default:
                    break;

            }

        }



        private void textbox_content_click(object o, EventArgs a)
        {
            // 생성한 Radio버튼 연결
            text = (TextBox)o;

            if (text.Name == "textbox_content" && contentclick_initchk == 0)
            {
                textbox_content.Text = "";
                contentclick_initchk = 1;
            }

            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }
        private void textbox_emailadress_click(object o, EventArgs a)
        {
            // 생성한 Radio버튼 연결
            text = (TextBox)o;

            if (text.Name == "textbox_emailadress" && emailclick_initchk == 0)
            {
                textbox_emailadress.Text = "";
                emailclick_initchk = 1;
            }

            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }

        private void button_send_click(object o, EventArgs a)
        {
            // 생성한 Radio버튼 연결
            btn = (Button)o;
            this.Close();
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
