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
        public WeekPlanner()
        {
            InitializeComponent();
            LoadView();
        }

        private void WeekPlanner_Load(object sender, EventArgs e)
        {

        }

        private void LoadView()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var label = new Label();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Dock = DockStyle.Fill;
                    label.Click += Label_Click;
                    label.Click += (sen, ev) => this.UpdateView();
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

        public void UpdateView()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tableLayoutPlan.GetControlFromPosition(i, j).Show();
                    tableLayoutPlan.SetRowSpan(tableLayoutPlan.GetControlFromPosition(i, j), 1);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int len = planer.GetSimilarPeriodsLength(i, j);
                    if(len == 1)
                    {
                        tableLayoutPlan.GetControlFromPosition(i, j).Text = planer.GetPeriod(i, j).Text + "\n" + planer.GetPeriod(i, j).Start.TimeOfDay.ToString();
                        tableLayoutPlan.GetControlFromPosition(i, j).BackColor = planer.GetPeriod(i, j).Color;
                    }
                    else
                    {
                        /*for (int k = j; k < j + len; k++)
                        {
                            tableLayoutPlan.GetControlFromPosition(i, k).Hide();
                        }
                        tableLayoutPlan.GetControlFromPosition(i, j).Show();
                        tableLayoutPlan.GetControlFromPosition(i, j).Text = planer.GetPeriod(i, j).Text;
                        tableLayoutPlan.GetControlFromPosition(i, j).BackColor = planer.GetPeriod(i, j).Color;
                        tableLayoutPlan.SetRowSpan(tableLayoutPlan.GetControlFromPosition(i, j), len);
                        j += len-1;*/

                        for (int k = j; k <= j + len; k++)
                        {
                            tableLayoutPlan.GetControlFromPosition(i, k).Text = String.Empty;
                            tableLayoutPlan.GetControlFromPosition(i, k).BackColor = planer.GetPeriod(i, j).Color;
                        }

                        tableLayoutPlan.GetControlFromPosition(i, j).Text = planer.GetPeriod(i, j).Text;
                        tableLayoutPlan.GetControlFromPosition(i, j).BackColor = planer.GetPeriod(i, j).Color;
                        j += len - 1;
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
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

        public void SetPeriodValue(int col, int row, string text, Color color)
        {
            planer.SetPeriodValue(col, row, text, color);
            UpdateView();
        }

        public void SetSelectedPeriodsValue(string text, Color color)
        {
            planer.SetPeriodValue(text, color, selectedPeriods.GetSelectedPeriods());
            UpdateView();
        }

 
    }
}
