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

namespace MemoryGame
{
    public partial class Ranking : Form
    {
        public Ranking()
        {   
            InitializeComponent();
            LoadRanking();
        }

        public Ranking(string nick, int score)
        {
            InitializeComponent();
            AddRecordToFile(nick, score);
            LoadRanking();
            label3.Text = "Twój wynik: " + score.ToString();
            label1.Text = "Wygrana";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        void AddRecordToFile(string name, int score)
        {
            // Reads file into list
            List<(string, int)> records = new List<(string, int)>();
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"Settings\\ranking.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    records.Add((row[0], int.Parse(row[1])));
            }

            // Chech for any duplicate
            var f = records.Where(x => x.Item1 == name);

            // If duplicate occur, update score only if new one is better
            if (f.Any())
            {
                if(f.First().Item2 < score)
                {
                    records.Remove(f.First());
                    records.Add((name, score));
                }
            } else {
                // Otherwise add score
                records.Add((name, score));
            }

            // Sorting by points
            records.Sort((x, y) => y.Item2.CompareTo(x.Item2));
            // Remove last elements if list is too long to keep ranking short
            if(records.Count > 50)
            {
                records.RemoveAt(records.Count - 1);
            }

            // Empty file
            File.WriteAllText(@"Settings\\ranking.csv", string.Empty);
            // Save ranking to file
            using (StreamWriter sw = File.AppendText(@"Settings\\ranking.csv"))
            {
                foreach((string, int) r in records)
                {
                    sw.WriteLine(r.Item1 + ", " + r.Item2.ToString(), true);
                }
            }
        }

        // Read file and add scores to listBox1
        void LoadRanking()
        {
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"Settings\\ranking.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ", " });
            StringBuilder sb = new StringBuilder();
            while (!parser.EndOfData)
            {
                StringBuilder sb2 = new StringBuilder();
                string[] row = parser.ReadFields();
                sb2.Append(row[0]);
                sb2.Append(" ");
                sb2.Append(row[1]);
                listBox1.Items.Add(sb2.ToString());
            }
        }

        private void Ranking_Load(object sender, EventArgs e)
        {

        }
    }
}
