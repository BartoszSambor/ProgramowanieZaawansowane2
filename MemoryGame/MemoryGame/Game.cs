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

namespace MemoryGame
{
    public partial class Game : Form
    {
        // counting time of the game
        private Stopwatch watch;
        // player can't pause game after revealing first card
        private bool hadStarted = false;
        // time counting will not start until all cards will hide
        private bool cardsWereHidden = false;
        // store game settings
        private Settings settings;
        // helper variables
        PictureBox firstClicked = null;
        PictureBox secondClicked = null;
        // images
        private Image hideImage;
        private Image reversImage;
        // storing original images of cards (before reversing)
        List<(PictureBox, Image)> images = new List<(PictureBox, Image)>();
        // Pausing game
        bool isPaused = false;

        public Game(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();
            AddItems(settings.cardCount);
            hideImage = Image.FromFile(@"Pictures\\zzzEmpty.png");
            reversImage = Image.FromFile(@"Pictures\\zzz2.png");
        }

        private Size CalculateTableSize(int cardCount)
        {
            int rowCount = 0, colCount = 0;

            double sqrt = Math.Sqrt(cardCount);
            int i_sqrt = (int)sqrt;

            // try to get square as small as possible
            if (i_sqrt * i_sqrt == cardCount)
            {
                rowCount = colCount = i_sqrt;
            } 
            // add row if square is too small
            else if (i_sqrt * (i_sqrt + 1) >= cardCount)
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt;
            }
            // make bigger square if adding row was not enough
            else 
            {
                rowCount = i_sqrt + 1;
                colCount = i_sqrt + 1;
            }
            return new Size(rowCount, colCount);
        }

        private void AddItems(int count)
        {
            Size s = CalculateTableSize(count);
            int rowCount = s.Width, colCount = s.Height;

            // add rows (4 rows are from begining)
            for (int i = 4; i < rowCount; i++)
            {
                RowStyle temp = tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1];
                tableLayoutPanel.RowCount++;
                //add a new RowStyle as a copy of the previous one
                tableLayoutPanel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            }
            // add columns (4 rows are from begining)
            for (int i = 4; i < colCount; i++)
            {
                ColumnStyle temp = tableLayoutPanel.ColumnStyles[tableLayoutPanel.ColumnCount - 1];
                tableLayoutPanel.ColumnCount++;
                //add a new ColumnStyle as a copy of the previous one
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(temp.SizeType, temp.Width));
            }
            LoadAndCreateCards(count);

        }

        private void LoadAndCreateCards(int count)
        {
            // names of all png files in Cards directory
            string[] files = System.IO.Directory.GetFiles(@"Cards", "*.png");

            // names of png files but every name have its duplicate
            string[] names = new string[count];
            for (int i = 0; i < count / 2; i++)
            {
                names[i * 2] = files[i];
                names[i * 2 + 1] = files[i];
            }

            // shuffle array using "Fisher-Yates shuffle"
            Random rng = new Random();
            int n = names.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string temp = names[n];
                names[n] = names[k];
                names[k] = temp;
            }

            // create cards
            for (int i = 0; i < count; i++)
            {
                Image image1 = Image.FromFile(names[i]);
                PictureBox p = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    BackColor = SystemColors.ActiveCaption,
                    Image = image1,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                p.Click += new EventHandler(pictureBoxClicked);
                // set tag to compare later if two cards had same image
                p.Tag = names[i];
                tableLayoutPanel.Controls.Add(p);

                // all cards will be reversed (by changing image), so this list store original images
                images.Add((p, image1));
            }

        }

        // Any card clicked
        private void pictureBoxClicked(object sender, EventArgs e)
        {
            // Player can't do anything while game is paused
            if (isPaused)
                return;

            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            PictureBox clickedLabel = sender as PictureBox;


            if (clickedLabel != null)
            {
                // If player clicked card and game is not paused he can't pause game again
                hadStarted = true;
                pauseButton.Enabled = false;


                // If the clicked picture is not reversed, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.Image != reversImage)
                    return;

                // If firstClicked is null, this is the first icon 
                // in the pair that the player clicked,
                // so set firstClicked to the picture that the player 
                // clicked, change its image, and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.Image = images.Find((x) => x.Item1 == firstClicked).Item2;
                    return;
                }

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set its image
                secondClicked = clickedLabel;
                secondClicked.Image = images.Find((x) => x.Item1 == secondClicked).Item2;

                // If the player clicked two matching icons, keep them 
                // visuble for short moment and reset firstClicked and secondClicked 
                // so the player can click another icon
                if (firstClicked.Tag == secondClicked.Tag)
                {
                    CheckForWinner();
                    var t = new Timer();
                    t.Interval = (int)(settings.hideTime*1000);
                    PictureBox f = firstClicked;
                    PictureBox s = secondClicked;
                    t.Tick += delegate { f.Image = hideImage; s.Image = hideImage; t.Stop(); };
                    t.Start();
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // If the player gets this far, the player 
                // clicked two different icons, so start the timer
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
                    if (iconLabel.Image == reversImage)
                        return;
                }
            }
            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            RevealAllCards();
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
            timer1.Stop();

            firstClicked.Image = reversImage;
            secondClicked.Image = reversImage;

            firstClicked = null;
            secondClicked = null;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timer2.Interval = settings.timeToRemember*1000;
            RevealAllCards();
            timer2.Start();
            timer1.Interval = (int)(settings.hideTime * 1000);
            label2.Text = (trackBar1.Value * 100).ToString() + " ms";
            // Watch will start counting time after all cards are hidden
            watch = new Stopwatch();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            HideAllCards();
            // Start counting time
            watch.Start();
        }

        private void HideAllCards()
        {
            cardsWereHidden = true;
            foreach (Control control in tableLayoutPanel.Controls)
            {
                PictureBox iconLabel = control as PictureBox;

                if (iconLabel != null)
                {
                    iconLabel.Image =  reversImage;
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
                    iconLabel.Image = images.Find((x) => x.Item1 == iconLabel).Item2;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = (trackBar1.Value * 100).ToString() + " ms";
            timer1.Interval = trackBar1.Value * 100;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            // do nothing if player already revealted any card
            // or if all cards are revealted at the beggining
            if (hadStarted || !cardsWereHidden)
            {
                return;
            }

            isPaused = !isPaused;
            if (isPaused)
            {
                pauseButton.Text = "Start";
                watch.Stop();
            } else
            {
                pauseButton.Text = "Stop";
                watch.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = watch.Elapsed.Seconds.ToString();
        }
    }
}
