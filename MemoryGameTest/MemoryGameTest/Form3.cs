using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameTest
{
    public partial class Form3 : Form
    {
        PictureBox firstClicked = null;
        PictureBox secondClicked = null;

        public Form3(int boardSize)
        {
            InitializeComponent();
            AddItems(boardSize);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void AddItems(int count)
        {
            int rowCount=0, colCount=0;

            double sqrt = Math.Sqrt(count);
            int i_sqrt = (int)sqrt;

            if(i_sqrt * i_sqrt == count)
            {
                rowCount = colCount = i_sqrt;
            }
            else if(i_sqrt * (i_sqrt + 1) >= count)
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt;
            }
            else
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt + 1;
            }

            

            for(int i = 4; i < rowCount; i++)
            {
                RowStyle temp = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
                //increase panel rows count by one
                tableLayoutPanel1.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            }

            for (int i = 4; i < colCount; i++)
            {
                ColumnStyle temp = tableLayoutPanel1.ColumnStyles[tableLayoutPanel1.ColumnCount - 1];
                //increase panel rows count by one
                tableLayoutPanel1.ColumnCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(temp.SizeType, temp.Width));
            }


            string[] files = System.IO.Directory.GetFiles(@"c:\\Users\\Bartek\\Desktop\\tmp22", "*.png");
            string[] names = new string[count];

            for (int i = 0; i < count / 2; i++)
            {
                names[i*2] = files[i];
                names[i*2+1] = files[i];
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
                tableLayoutPanel1.Controls.Add(p);

            }
            //tableLayoutPanel1.Controls.Add(new Label() { Text = text }, 0, tableLayoutPanel1.RowCount - 1);

        }

        private void pictureBoxClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("pictureBoxClicked");
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            PictureBox clickedLabel = sender as PictureBox;


            if (clickedLabel != null)
            {
                Debug.WriteLine("pictureBoxClicked in loop");

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



        private string GetRandomLetter()
        {
            var letters = new string[] {"a", "b", "c", "d", "e" };
            return letters[new Random().Next(0, 5)];
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
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
/*            var f = new Form4();
            f.ShowDialog();*/
            Close();
        }
    }
}
