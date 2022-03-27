﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Game : Form
    {
        private Stopwatch watch;
        private Settings settings;
        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        private Image hideImage;
        List<(PictureBox, Image)> images = new List<(PictureBox, Image)>();
        public Game(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
            AddItems(settings.cardCount);
            hideImage = Image.FromFile(@"c:\\Users\\Bartek\\Desktop\\tmp22\\zzz.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddItems(int count)
        {
            int rowCount = 0, colCount = 0;

            double sqrt = Math.Sqrt(count);
            int i_sqrt = (int)sqrt;

            if (i_sqrt * i_sqrt == count)
            {
                rowCount = colCount = i_sqrt;
            }
            else if (i_sqrt * (i_sqrt + 1) >= count)
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt;
            }
            else
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt + 1;
            }



            for (int i = 4; i < rowCount; i++)
            {
                RowStyle temp = tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            }

            for (int i = 4; i < colCount; i++)
            {
                ColumnStyle temp = tableLayoutPanel.ColumnStyles[tableLayoutPanel.ColumnCount - 1];
                //increase panel rows count by one
                tableLayoutPanel.ColumnCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(temp.SizeType, temp.Width));
            }


            string[] files = System.IO.Directory.GetFiles(@"c:\\Users\\Bartek\\Desktop\\tmp22", "*.png");
            string[] names = new string[count];

            for (int i = 0; i < count / 2; i++)
            {
                names[i * 2] = files[i];
                names[i * 2 + 1] = files[i];
            }

            Debug.WriteLine("start");
            foreach (var a in names)
            {
                Debug.WriteLine(a);
            }

            Random rng = new Random();
            int n = names.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string temp = names[n];
                names[n] = names[k];
                names[k] = temp;
            }

            for (int i = 0; i < count; i++)
            {
                /*tableLayoutPanel1.Controls.Add(new Label() {
                    Text = GetRandomLetter(), 
                    Font = new Font("Webdings", 10), 
                    AutoSize = false, 
                    Size = new Size(100,100), 
                    Dock = DockStyle.Fill 
                });

                 //get a reference to the previous existent 
                RowStyle temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel1.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                //add your three controls
                tableLayoutPanel1.Controls.Add(new Label() { Text = address }, 0, tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = contactNum }, 1, tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = email }, 2, tableLayoutPanel1.RowCount - 1);

*/


                //Image image1 = Image.FromFile("c:\\Users\\Bartek\\Desktop\\tmp22\\ammonite.png");
                Image image1 = Image.FromFile(names[i]);
                image1.Tag = names[i];
                PictureBox p = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White,
                    Image = image1,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p.Click += new EventHandler(pictureBoxClicked);
                tableLayoutPanel.Controls.Add(p);

            }
            //tableLayoutPanel1.Controls.Add(new Label() { Text = text }, 0, tableLayoutPanel1.RowCount - 1);

        }

        private void pictureBoxClicked(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            PictureBox clickedLabel = sender as PictureBox;


            if (clickedLabel != null)
            {

                // If the clicked label is black, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.BackColor == Color.Black)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the label that the player 
                // clicked, change its color to black, and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.BackColor = Color.Black;

                    return;
                }

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set its color to black
                secondClicked = clickedLabel;
                secondClicked.BackColor = Color.Black;

                // Check to see if the player won
                CheckForWinner();

                // If the player clicked two matching icons, keep them 
                // black and reset firstClicked and secondClicked 
                // so the player can click another icon
                if (firstClicked.Image.Tag == secondClicked.Image.Tag)
                {
                   /* firstClicked.Image = hideImage;
                    secondClicked.Image = hideImage;*/
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // If the player gets this far, the player 
                // clicked two different icons, so start the 
                // timer (which will wait three quarters of 
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                PictureBox iconLabel = control as PictureBox;

                if (iconLabel != null)
                {
                    if (iconLabel.BackColor == Color.White)
                        return;
                }
            }
            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            watch.Stop();
            int time = watch.Elapsed.Seconds;
            int score = 1000 - time * 10 + settings.cardCount * 5;
            if (score < 0)
                score = 0;
            var f = new Ranking(settings.nick, score);
            f.ShowDialog();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.BackColor = Color.White;
            secondClicked.BackColor = Color.White;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timer2.Interval = settings.timeToRemember*1000;
            RevealAllCards();
            timer2.Start();
            watch = new Stopwatch();
            watch.Start();
            timer1.Interval = (int)(settings.hideTime * 1000);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            HideAllCards();
        }

        private void HideAllCards()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                PictureBox iconLabel = control as PictureBox;

                if (iconLabel != null)
                {
                    iconLabel.BackColor = Color.White;
                }
            }

        }

        private void RevealAllCards()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                PictureBox iconLabel = control as PictureBox;

                if (iconLabel != null)
                {
                    iconLabel.BackColor = Color.Black;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = (trackBar1.Value * 100).ToString() + " ms";
            timer1.Interval = trackBar1.Value * 100;
        }

    }
}
