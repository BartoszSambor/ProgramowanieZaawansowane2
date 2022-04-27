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

            comboBox2.Items.Clear();
            comboBox2.DataSource = Enum.GetValues(typeof(Fuel));
            Clear();
        }

        // Open file dialog to load car image
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.png;*.jpg)|*.png;*.jpg";
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

        // Save car
        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidateDataCompleteness())
            {
                MessageBox.Show("Nie uzupełniono wymaganych danych", "Błąd");
                return;
            }

            var car = CreateCar();
            car.SaveImage();
            Debug.WriteLine(car.ToCSV());
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
            comboBox2.Text = "Wybierz";
            comboBox1.Text = "Wybierz";

        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Rok musi być liczbą całkowitą", "Błąd");
                e.Cancel = true;
                textBox3.Select(0, textBox3.Text.Length);
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            int millage;
            if (!int.TryParse(textBox4.Text, out millage) || millage < 0)
            {
                MessageBox.Show("Przebieg musi być liczbą całkowitą dodatnią", "Błąd");
                e.Cancel = true;
                textBox4.Select(0, textBox4.Text.Length);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            int price;
            if (!int.TryParse(textBox5.Text, out price) || price < 0)
            {
                MessageBox.Show("Cena musi być liczbą całkowitą dodatnią", "Błąd");
                e.Cancel = true;
                textBox5.Select(0, textBox5.Text.Length);
            }
        }

        private bool ValidateDataCompleteness()
        {
            bool result = true;
            if (textBox1.Text == string.Empty) result = false;
            if (textBox2.Text == string.Empty) result = false;
            if (textBox3.Text == string.Empty) result = false;
            if (textBox4.Text == string.Empty) result = false;
            if (textBox5.Text == string.Empty) result = false;
            if (comboBox1.SelectedIndex == -1) result = false;
            if (comboBox2.SelectedIndex == -1) result = false;
            return result;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
