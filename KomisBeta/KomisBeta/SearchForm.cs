using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace KomisBeta
{
    public partial class SearchForm : Form
    {
        private List<Car> cars = null;
        private List<Car> currentCars = null;
        Menu parent;
        public SearchForm(Menu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public void AddCar(Car car)
        {
            if(cars != null)
            {
                cars.Append(car);
            }
        }


        private void SearchForm_Load(object sender, EventArgs e)
        {
            LoadCarsFromFile();
        }

        private void LoadCarsFromFile()
        {
            cars = new List<Car>();
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"data\\data.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                var car = new Car(
                        row[0],
                        row[1],
                        (Body)Enum.Parse(typeof(Body), row[2]),
                        (Fuel)Enum.Parse(typeof(Fuel), row[3]),
                        int.Parse(row[4]),
                        int.Parse(row[5]),
                        int.Parse(row[6]),
                        Image.FromFile(row[7]),
                        row[7]
                    );

                cars.Add(car);
            }
            foreach (var a in cars)
            {
                Debug.WriteLine(a.ToCSV());
            }
            currentCars = GetFilteredCars();
            FilterComboBox();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            LoadCarsFromFile();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.RowStyles.Clear();
            List<Car> carsTmp;
            carsTmp = GetFilteredCars();
            tableLayoutPanel1.Controls.Clear();
            foreach (var car in carsTmp)
            {
                Debug.WriteLine(car.ToCSV());
                CarView c = new CarView(car, parent)
                {
                    Dock = DockStyle.Fill,
                    BackColor = SystemColors.ActiveCaption,
                };
                tableLayoutPanel1.Controls.Add(c);
            }
            tableLayoutPanel1.ResumeLayout();
            currentCars = GetFilteredCars();
            FilterComboBox();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private List<Car> GetFilteredCars()
        {
            List<Car> carsTmp = cars;
            if (comboBox3.SelectedItem != null)
            {
                carsTmp = carsTmp.Where(x => x.brand == comboBox3.SelectedItem.ToString()).ToList();
            }
            if (comboBox4.SelectedItem != null)
            {
                carsTmp = carsTmp.Where(x => x.model == comboBox4.SelectedItem.ToString()).ToList();
            }
            if (comboBox1.SelectedItem != null)
            {
                carsTmp = carsTmp.Where(x => x.body.ToString() == comboBox1.SelectedItem.ToString()).ToList();
            }
            if (comboBox2.SelectedItem != null)
            {
                carsTmp = carsTmp.Where(x => x.fuel.ToString() == comboBox2.SelectedItem.ToString()).ToList();
            }
            if(textBox1.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.price >= int.Parse(textBox1.Text)).ToList();
            }
            if (textBox2.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.price <= int.Parse(textBox2.Text)).ToList();
            }
            if (textBox4.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.year >= int.Parse(textBox4.Text)).ToList();
            }
            if (textBox3.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.year <= int.Parse(textBox3.Text)).ToList();
            }
            if (textBox6.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.mileage >= int.Parse(textBox6.Text)).ToList();
            }
            if (textBox5.Text != String.Empty)
            {
                carsTmp = carsTmp.Where(x => x.mileage <= int.Parse(textBox5.Text)).ToList();
            }

            return carsTmp;
        }

        private void FilterComboBox()
        {
            var c1 = comboBox1.SelectedItem;
            comboBox1.Items.Clear();
            var items = currentCars.Select(x => x.body.ToString()).Distinct();
            foreach (var a in items)
            {
                comboBox1.Items.Add(a);
            }
            comboBox1.SelectedItem = c1;

            var c2 = comboBox2.SelectedItem;
            comboBox2.Items.Clear();
            var items2 = currentCars.Select(x => x.fuel.ToString()).Distinct();
            foreach (var a in items2)
            {
                comboBox2.Items.Add(a);
            }
            comboBox2.SelectedItem = c2;

            var c3 = comboBox3.SelectedItem;
            comboBox3.Items.Clear();
            var items3 = currentCars.Select(x => x.brand.ToString()).Distinct();
            foreach (var a in items3)
            {
                comboBox3.Items.Add(a);
            }
            comboBox3.SelectedItem = c3;

            var c4 = comboBox4.SelectedItem;
            comboBox4.Items.Clear();
            var items4 = currentCars.Select(x => x.model.ToString()).Distinct();
            foreach (var a in items4)
            {
                comboBox4.Items.Add(a);
            }
            comboBox4.SelectedItem = c4;            
        }

        private void ResetComboBox()
        {
            comboBox1.SelectedItem = null;
            comboBox1.Items.Clear();
            comboBox2.SelectedItem = null;
            comboBox2.Items.Clear();
            comboBox3.SelectedItem = null;
            comboBox3.Items.Clear();
            comboBox4.SelectedItem = null;
            comboBox4.Items.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            currentCars = cars;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            ResetComboBox();
            button3_Click(this, e);
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            this.SearchForm_Load(this, e);
        }



        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {
            if(comboBox3.Items.Count > 1)
                UpdateList();
        }



        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Items.Count > 1)
                UpdateList();
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Items.Count > 1)
                UpdateList();
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Items.Count > 1)
                UpdateList();
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox4, sender, e);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox3, sender, e);
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox6, sender, e);
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox5, sender, e);
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox1, sender, e);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBoxPositiveOr0Int(textBox2, sender, e);
        }

        // Checks if provided TextBox contains non-negative integer
        private void ValidateTextBoxPositiveOr0Int(TextBox tb, object sender, CancelEventArgs e)
        {
            int value;
            if (!int.TryParse(tb.Text, out value) || value < 0)
            {
                MessageBox.Show("Cena musi być liczbą całkowitą dodatnią", "Błąd");
                e.Cancel = true;
                tb.Select(0, tb.Text.Length);
            }
        }
    }
}
