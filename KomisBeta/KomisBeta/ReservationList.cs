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
            LoadReservations();
        }

        public void SelectCar(Car selectedCar)
        {
            this.selectedCar = selectedCar;
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
            List<(string, DateTime)> reservations = new List<(string, DateTime)>();

            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"data\\reservations.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            Debug.WriteLine("RESERVATIONS");
            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                foreach(var x in row)
                {
                    Debug.WriteLine(x);
                }
                reservations.Add((row[1], DateTime.Parse(row[0])));
            }
            foreach (var a in reservations)
            {
                Debug.WriteLine(a.Item1 + " " + a.Item2);
                listBox1.Items.Add(
                    a.Item2.ToString() + "\t" + a.Item2.AddHours(1).ToString()
                    );
            }


        }

        private void AddReservation()
        {
            File.AppendAllText("data/reservations.csv", dateTimePicker1.Value + ", " + selectedCar.filePath + Environment.NewLine);
        }
    }
}
