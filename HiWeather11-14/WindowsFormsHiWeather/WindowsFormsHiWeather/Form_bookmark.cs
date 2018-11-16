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
    public partial class Form_bookmark : Form
    {
        TabControl tab = new TabControl();
        TabPage tabPage1=new TabPage();
        TabPage tabPage2=new TabPage();
        
        public Form_bookmark()
        {
            InitializeComponent();

            Load += Form_bookmark_Load;
            //MessageBox.Show("테스트");
        }

        private void Form_bookmark_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000,600);
            this.BackColor = Color.AliceBlue;

            Button button = new Button();
            button.DialogResult = DialogResult.OK;
            button.Name = "button1";
            button.Text = "설정";
            button.Size = new Size(100,100);
            button.Location = new Point(800, 0);
            button.Cursor = Cursors.Hand;
            button.BringToFront();

            this.Controls.Add(button);

            TabControl tb =tb_create();
            /*tb.TabPages.Add(MainLabelCreate());
            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tb.TabPages.Add(pn_create(i, j));
                }
            }
            */
            tb.SendToBack();
            Controls.Add(tb);
            
        }
        private TabControl tb_create(){
            tab.Controls.Add(tabPage1);
            tab.Controls.Add(tabPage2);
            tab.SelectedIndex = 0;
            tab.Size = new Size(990, 600);
            tab.TabIndex = 0;
            tab.ItemSize = new Size(80,70);

             tabPage1.Location = new Point(0,0);
            tabPage1.Size = new Size(400, 400);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "일기예보";
            tabPage1.UseVisualStyleBackColor = true;

             tabPage2.Location = new Point(80,0);
            tabPage2.Size = new Size(400, 400);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "즐겨찾기";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.BackColor = Color.AliceBlue; 
            tabPage2.Controls.Add(MainLabelCreate());
            
            tabPage2.Controls.Add(pn_create(0, 0));
            /*
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabPage2.Controls.Add(pn_create(i, j));
                }
            }*/
            return tab;
        }
        private Label MainLabelCreate()
        {
            Label label;
            label = new Label();
            label.Name = "label";
            label.Text = "즐겨찾기";
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(0, 0);
            label.Size = new Size(100, 20);
            label.Font = new Font(FontFamily.GenericSansSerif, 15.0F, FontStyle.Bold);
            
            
            return label;
        }
        private Panel pn_create(int i, int j)
        {
            Panel p = new Panel();
            Label label = new Label();
            Label label1 = new Label();
            PictureBox weather = new PictureBox();
            PictureBox picture = new PictureBox();

            p.Name = "panel" + (i * 2 + j + 1);
            p.Location = new Point(20 + i * 435, 35 + j * 140);
            p.Size = new Size(405, 120);
            p.BorderStyle = BorderStyle.FixedSingle;

            label.Text = "금천구, 서울특별시";
            label.Location = new Point(120, 10);
            label.Size = new Size(300, 30);
            label.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);

            label1.Text = (13).ToString() + "˚C";
            label1.Location = new Point(150, 50);
            label1.Size = new Size(50, 20);
            label1.Font = new Font(FontFamily.GenericSerif, 14.0F);
            
            
            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("sunny");
            weather.SizeMode = PictureBoxSizeMode.StretchImage;
            weather.Location = new Point(10, 10);
            weather.Size = new Size(100, 100);

            picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust2");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(200, 45);
            picture.Size = new Size(50, 50);


            p.Controls.Add(label);
            p.Controls.Add(label1);
            p.Controls.Add(weather);
            p.Controls.Add(picture);

            return p;
        }
        
    }
}
