using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carimagery
{
    public partial class Form1 : Form
    {
        CarImagery.apiSoapClient carImagery = new CarImagery.apiSoapClient("apiSoap");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "pobieranie";
            var strUrl = carImagery.GetImageUrl(textBox1.Text);
            WebClient client = new WebClient();
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            client.DownloadFileAsync(new Uri(strUrl), @"car.png");

        }



        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            label1.Text = "ukończono";
            pictureBox1.Image = Image.FromFile(@"car.png");
        }
    }
}
