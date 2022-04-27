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
    public partial class ReservationList : Form
    {
        Car selectedCar = null;

        //list containing: Car id, reservation time, user name
        List<(string, DateTime, string)> reservations; 
        public ReservationList()
        {
            InitializeComponent();
        }

        public void SelectCar(Car selectedCar)
        {
            this.selectedCar = selectedCar;
            reservations = new List<(string, DateTime, string)>();
            LoadReservations();
        }

        private void ReservationList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddReservation();
        }

        private void LoadReservations()
        {
            //Clear list
            reservations.Clear();

            //Load reservations list from file
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"data\\reservations.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            Debug.WriteLine(selectedCar.filePath);
            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                foreach(var x in row)
                {
                    Debug.WriteLine(x);
                }
                reservations.Add((row[1], DateTime.Parse(row[0]), row[2]));
            }

            //Sort reservations by starting time
            reservations.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            //Set Listbox1 content to selected car reservations
            reservations = reservations.Where(x => x.Item1.ToString().Equals(selectedCar.filePath)).ToList();
            listBox1.Items.Clear();
            foreach (var a in reservations)
            {
                Debug.WriteLine(a.Item1 + " " + a.Item2 + " " + a.Item2.ToString().Substring(5));
                listBox1.Items.Add(
                    a.Item2.ToString() + "\t" + a.Item2.AddHours(1).ToString()
                    + "\t" + a.Item3
                    );
            }
        }

        private void AddReservation()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Nie podano nazwy osoby rezerwującej", "Błąd");
                return;
            }

            // Check if no reservation collide with selected time
            var startTime = dateTimePicker1.Value;
            var endTime= dateTimePicker1.Value.AddHours(1);
            foreach(var elem in reservations)
            {
                var r_startTime = elem.Item2;
                var r_endTime = r_startTime.AddHours(1);

                if( (r_startTime <= startTime && startTime <= r_endTime) || 
                    (r_startTime <= endTime && endTime <= r_endTime))
                {
                    MessageBox.Show("Podana data koliduje z istniejącymi rezerwacjami", "Błąd");
                    return;
                }
            }

            File.AppendAllText("data/reservations.csv", dateTimePicker1.Value + ", " + selectedCar.filePath + ", " + textBox1.Text + Environment.NewLine);
            LoadReservations();
        }
    }
}
