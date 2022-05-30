using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WeekCalendar
{
    public partial class WeekPlanner: UserControl
    {
        Planner planer = new Planner();
        SelectedPeriods selectedPeriods = new SelectedPeriods();
        NotificationManager notifications = new NotificationManager();
        bool showMsgBox = false;
        uint minutesBefore = 15;
        public WeekPlanner()
        {
            InitializeComponent();
            LoadView();
            buttonColorChange.BackColor = colorDialog1.Color;
            UpdateWeekLabel();
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when event is coming (15 min)")]
        public event EventHandler EventReminder;


        [Description("Show messege before planned event"), Category("Behavior")]
        public bool ShowMsgBox
        {
            get => showMsgBox;
            set => showMsgBox = value;
        }

        [Description("Remind about planner event before x minutes"), Category("Behavior")]
        public uint RemindBefore
        {
            get => minutesBefore;
            set { minutesBefore = value;
                notifications.SetTimeBefore(minutesBefore);
            }
        }
        

        private void LoadView()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    var label = new Label();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Dock = DockStyle.Fill;
                    label.Click += Label_Click;
                    //
                    int k = i;
                    int l = j;
                    //
                    label.Click += (sen, ev) => this.UpdateView(k, l);
                    tableLayoutPlan.Controls.Add(label, i, j);
                }
            }
            UpdateView();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label selected = sender as Label;
            if(!(selected is null))
            {
                var p = tableLayoutPlan.GetPositionFromControl(selected);
                selectedPeriods.SelectPeriod(planer.GetPeriod(p.Column, p.Row));
            }
        }
        
        // Draw GUI
        public void UpdateView(int col, int row)
        {

            if (selectedPeriods.IsSelected(col, row))
            {
                Label lab = tableLayoutPlan.GetControlFromPosition(col, row) as Label;
                lab.BorderStyle = BorderStyle.FixedSingle;

            }
            else
            {
                Label lab = tableLayoutPlan.GetControlFromPosition(col, row) as Label;
                lab.BorderStyle = BorderStyle.None;
            }
            
            
            var unselected = selectedPeriods.GetPreviouslySelected();
            foreach(var p in unselected)
            {
                int x = p.Column;
                int y = p.Row;
                if (selectedPeriods.IsSelected(x, y))
                {
                    Label lab = tableLayoutPlan.GetControlFromPosition(x, y) as Label;
                    lab.BorderStyle = BorderStyle.FixedSingle;

                }
                else
                {
                    Label lab = tableLayoutPlan.GetControlFromPosition(x, y) as Label;
                    lab.BorderStyle = BorderStyle.None;
                }
            }
        }
        // Draw GUI
        public void UpdateView()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    int len = planer.GetSimilarPeriodsLength(i, j);
                    if(len == 1)
                    {
                        tableLayoutPlan.GetControlFromPosition(i, j).Text = planer.GetPeriod(i, j).Text + "\n" + planer.GetPeriod(i, j).Start.TimeOfDay.ToString();
                        tableLayoutPlan.GetControlFromPosition(i, j).BackColor = planer.GetPeriod(i, j).Color;
                        var lab = tableLayoutPlan.GetControlFromPosition(i, j) as Label;
                        lab.TextAlign = ContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        for (int k = j; k < j + len; k++)
                        {
                            tableLayoutPlan.GetControlFromPosition(i, k).Text = String.Empty;
                            tableLayoutPlan.GetControlFromPosition(i, k).BackColor = planer.GetPeriod(i, j).Color;
                        }

                        tableLayoutPlan.GetControlFromPosition(i, j).Text = planer.GetPeriod(i, j).Text + "\n" + planer.GetPeriod(i, j).Start.TimeOfDay.ToString();
                        var lab1 = tableLayoutPlan.GetControlFromPosition(i, j) as Label;
                        lab1.TextAlign = ContentAlignment.TopLeft;
                        tableLayoutPlan.GetControlFromPosition(i, j + len - 1).Text = planer.GetPeriod(i, j + len - 1).End.TimeOfDay.ToString();
                        var lab = tableLayoutPlan.GetControlFromPosition(i, j + len - 1) as Label;
                        lab.TextAlign = ContentAlignment.BottomRight;
                        j += len - 1;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if(selectedPeriods.IsSelected(i, j))
                    {
                        Label lab = tableLayoutPlan.GetControlFromPosition(i, j) as Label;
                        lab.BorderStyle = BorderStyle.FixedSingle;

                    } else
                    {
                        Label lab = tableLayoutPlan.GetControlFromPosition(i, j) as Label;
                        lab.BorderStyle = BorderStyle.None;
                    }
                }
            }
        }

        public void SetSelectedPeriodsValue(string text, Color color)
        {
            planer.SetPeriodValue(text, color, selectedPeriods.GetSelectedPeriods());
            UpdateView();
            notifications.Load();
        }        

        private void buttonPrevWeek_Click(object sender, EventArgs e)
        {
            planer.LoadPreviousWeek();
            UpdateWeekLabel();
            UpdateView();
        }

        private void buttonNextWeek_Click(object sender, EventArgs e)
        {
            planer.LoadNextWeek();
            UpdateWeekLabel();
            UpdateView();
        }

        private void buttonColorChange_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColorChange.BackColor = colorDialog1.Color;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxDescription.Text == String.Empty)
            {
                MessageBox.Show("Input correct description");
                return;
            }
            SetSelectedPeriodsValue(textBoxDescription.Text, colorDialog1.Color);
        }

        private void UpdateWeekLabel()
        {
            labelWeeks.Text = planer.GetDate().ToString("d") + " - " + planer.GetDate().AddDays(6).ToString("d");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var p = notifications.GetPlannedEvent(DateTime.Now);
            if (p != null) {
                if (showMsgBox)
                {
                    MessageBox.Show("You have a planned event: " + p.Text + " in " + (p.Start - DateTime.Now).ToString("hh\\:mm\\:ss"));
                }
                EventReminder?.Invoke(this, e);
            } 
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.SetSelectedPeriodsValue(String.Empty, planer.defaulfColor);


        }
    }
}
