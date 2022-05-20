using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordReq
{
    public partial class ImageCheckBox : UserControl
    {
        private Image ok = Properties.Resources.OkImage;
        private Image x = Properties.Resources.XImage;
        private bool isChecked = false;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                if (isChecked)
                {
                    this.pictureBox1.Image = ok;
                }
                else
                {
                    this.pictureBox1.Image = x;
                }
            }
        }
        public void SetText(string text)
        {
            this.label1.Text = text;
        }
        public ImageCheckBox()
        {
            InitializeComponent();
            this.pictureBox1.Image = x;
        }

        [Description("Text text displayed in the textbox"), Category("Data")]
        public string LabelText
        {
            get => label1.Text;
            set => label1.Text = value;
        }


    }
}
