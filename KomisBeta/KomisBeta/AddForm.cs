using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KomisBeta
{
    public partial class AddForm : Form
    {
        private Image image = null;
        public AddForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.DataSource = Enum.GetValues(typeof(Body));
            comboBox1.Text = "Wybierz";

            comboBox2.Items.Clear();
            comboBox2.DataSource = Enum.GetValues(typeof(Fuel));
            comboBox2.Text = "Wybierz";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;

                    image = Image.FromFile(filePath);
                    pictureBox1.Image = image;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        Car CreateCar()
        {
            var car = new Car(
                textBox1.Text,
                textBox2.Text,
                (Body)comboBox1.SelectedItem,
                (Fuel)comboBox2.SelectedItem,
                int.Parse(textBox3.Text),
                int.Parse(textBox4.Text),
                int.Parse(textBox5.Text),
                image
                );
            return car;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var car = CreateCar();
            car.SaveImage();
            Debug.WriteLine(car.ToCSV());
/*            using (StreamWriter sw = File.CreateText("data/data.csv"))
            {
                sw.WriteLine(car.ToCSV());
            }*/
            File.AppendAllText("data/data.csv", car.ToCSV() + Environment.NewLine);
            this.Clear();
        }

        private void Clear()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            pictureBox1.Image = Properties.Resources.CarDefault;
        }
    }
}
