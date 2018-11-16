using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsHiWeather
{
    class Drawclass
    {
        public void btn(Btnclass bc)
        {
           Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bc.Name;
            btn.Text = bc.Text;
            btn.Size = new Size(bc.SX, bc.SY);
            btn.Location = new Point(bc.PX, bc.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += bc.eh;
            btn.BackColor = Color.Transparent;
            bc.Form.Controls.Add(btn);
            
        }
        public Button btn1(Btnclass bc)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bc.Name;
            btn.Text = "";
            btn.Size = new Size(bc.SX, bc.SY);
            btn.Location = new Point(bc.PX, bc.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += bc.eh;

            Image btn_myImage;

            if (btn.Name == "Home")
            {
                btn_myImage = (Image)Properties.Resources.Home;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "bookmark")
            {
                btn_myImage = (Image)Properties.Resources.bookmark;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "feedback")
            {
                btn_myImage = (Image)Properties.Resources.feedback;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "option")
            {
                btn_myImage = (Image)Properties.Resources.setting;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "rfbtn")
            {
                btn_myImage = (Image)Properties.Resources.refresh;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "bmbtn")
            {
                btn_myImage = (Image)Properties.Resources.Star;
                //MessageBox.Show(bc.Name);
            }
            else if (btn.Name == "bmbtn2")
            {
                btn_myImage = (Image)Properties.Resources.Star1;
                //MessageBox.Show(bc.Name);
            }
            else
            {
                btn_myImage = (Image)Properties.Resources.search_button;
            }

            //MessageBox.Show("패스");
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(255, 255);
            imageList.Images.Add(btn_myImage);
            if (btn.Name == "sbtn")
            {
                imageList.ImageSize = new Size(50, 32);
            }
            else if (btn.Name == "rfbtn"|| btn.Name == "bmbtn")
            {
                imageList.ImageSize = new Size(50, 32);
            }
            else
            imageList.ImageSize = new Size(70, 50);
            imageList.TransparentColor = Color.Transparent;

            btn.ImageIndex = 0;
            btn.ImageList = imageList;
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            return btn;

        }
       
        public Label lb(Lbclass lb)
        {
            Label label  = new Label(); 
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.BackColor = Color.Transparent;
            lb.Form.Controls.Add(label);

            return label;
        }
        public Label lb1(Lbclass lb,float tSize)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.Font = new Font(FontFamily.GenericSansSerif, tSize, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.BackColor = Color.Transparent;
            return label;
        }
        public Label lb2(Lbclass lb, float tSize)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.Font = new Font(FontFamily.GenericSansSerif, tSize, FontStyle.Bold);
            label.ForeColor = Color.WhiteSmoke;
            label.BackColor = Color.Transparent;
            return label;
        }
    }
}
