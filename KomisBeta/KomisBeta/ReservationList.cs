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
        public ReservationList()
        {
            InitializeComponent();
        }

        public void SelectCar(Car selectedCar)
        {
            this.selectedCar = selectedCar;
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
            List<(string, DateTime, string)> reservations = new List<(string, DateTime, string)>();

            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"data\\reservations.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            Debug.WriteLine("RESERVATIONS");
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

            Debug.WriteLine("RESERVATIONS22222");
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
            File.AppendAllText("data/reservations.csv", dateTimePicker1.Value + ", " + selectedCar.filePath + ", " + textBox1.Text + Environment.NewLine);
            LoadReservations();
        }
    }
}
