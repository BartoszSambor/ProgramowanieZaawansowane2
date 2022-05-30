using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekCalendar
{
    internal class Planner
    {
        Period[][] plan = new Period[7][];
        DateTime currentWeek;
        public Color defaulfColor = SystemColors.ActiveCaption;
        public Planner()
        {
            currentWeek = this.StartOfWeek(DateTime.Now);

            LoadSavedPeriods();
        }


        public void SetPeriodValue(string text, Color color, List<Period> periods)
        {
            foreach (Period period in periods)
            {
                plan[period.Column][period.Row].Text = text;
                plan[period.Column][period.Row].Color = color;
            }
            Save();
        }

        public void ClearPeriodValue(List<Period> periods)
        {
            foreach (Period period in periods)
            {
                plan[period.Column][period.Row].Text = String.Empty;
                plan[period.Column][period.Row].Color = defaulfColor;
            }
            Save();
        }

        public Period GetPeriod(int col, int row)
        {
            return plan[col][row];
        }

        public DateTime GetDate()
        {
            return currentWeek;
        }

        public int GetSimilarPeriodsLength(int col, int row)
        {
            int count = 1;
            for (int i = row + 1; i < 24; i++)
            {
                if (plan[col][i].Text != String.Empty && plan[col][i].Text == plan[col][row].Text && plan[col][i].Color == plan[col][row].Color)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            if(count > 1)
                Debug.WriteLine("count: " + count + " pos: " + col + " " + row);
            return count;
        }

        public DateTime StartOfWeek(DateTime dt)
        {
            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            return monday;
        }

        public void LoadNextWeek()
        {
            Save();
            currentWeek = currentWeek.AddDays(7);
            LoadSavedPeriods();
        }
        
        public void LoadPreviousWeek()
        {
            Save();
            currentWeek = currentWeek.AddDays(-7);
            LoadSavedPeriods();
        }

        private void LoadSavedPeriods()
        {
            var periods = new CSVManager().Load(currentWeek);
            if (periods != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    plan[i] = new Period[24];
                }
                for (int col = 0; col < 7; col++)
                {
                    for (int row = 0; row < 24; row++)
                    {
                        plan[col][row] = new Period(defaulfColor, String.Empty, col, row, true, this.StartOfWeek(DateTime.Now) + new TimeSpan(col, 0, row * 30, 0) + new TimeSpan(0, 8, 0, 0));
                    }
                }
                for (int col = 0; col < 7; col++)
                {
                    for (int row = 0; row < 24; row++)
                    {
                        plan[col][row].Copy(periods[col][row]);
                    }
                }
            } else
            {
                for (int i = 0; i < 7; i++)
                {
                    plan[i] = new Period[24];
                }
                for (int col = 0; col < 7; col++)
                {
                    for (int row = 0; row < 24; row++)
                    {
                        var s = col.ToString() + " " + row.ToString();
                        plan[col][row] = new Period(defaulfColor, String.Empty, col, row, true, currentWeek + new TimeSpan(col, 8, row * 30, 0));
                    }
                }
            }
        }

        public void Save()
        {
            new CSVManager().Save(currentWeek, plan);
        }
    }
}
