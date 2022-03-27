﻿using System;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void AddRecordToFile(string name, int score)
        {
            List<(string, int)> records = new List<(string, int)>();
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"c:\\Users\\Bartek\\Desktop\\tmp22\\ranking.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { "," });
            while (!parser.EndOfData)
                {
                    string[] row = parser.ReadFields();
                    records.Add((row[0], int.Parse(row[1])));
            }
            var f = records.Where(x => x.Item1 == name);

            if (f.Any())
            {
                if(f.First().Item2 < score)
                {
                    records.Remove(f.First());
                    records.Add((name, score));
                }
            } else {
                records.Add((name, score));
            }

            records.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            File.WriteAllText(@"c:\\Users\\Bartek\\Desktop\\tmp22\\ranking.csv", string.Empty);

            using (StreamWriter sw = File.AppendText(@"c:\\Users\\Bartek\\Desktop\\tmp22\\ranking.csv"))
            {
                foreach((string, int) r in records)
                {
                    sw.WriteLine(r.Item1 + ", " + r.Item2.ToString(), true);
                }
            }
        }

        void LoadRanking()
        {
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(@"c:\\Users\\Bartek\\Desktop\\tmp22\\ranking.csv");
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { "," });
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
    }
}
