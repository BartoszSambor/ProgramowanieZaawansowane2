using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomisBeta
{
    public partial class CarView : UserControl
    {
        Car car;
        Menu parent;
        public CarView(Car car, Menu parent)
        {
            this.parent = parent;
            this.car = car;
            InitializeComponent();
            label1.Text = car.brand;
            label2.Text = car.model;
            label3.Text = car.body.ToString();
            label4.Text = car.fuel.ToString();
            label5.Text = car.year.ToString();
            label6.Text = car.mileage.ToString();
            label7.Text = car.price.ToString();
            pictureBox1.Image = car.image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void CarView_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.SelectCar(car);
        }
    }
}
