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
        public Planner()
        {
            for (int i = 0; i < 7; i++)
            {
                plan[i] = new Period[10];
            }
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row < 10; row++)
                {
                    plan[col][row] = new Period(SystemColors.ActiveCaption, col.ToString() + " " + row.ToString(), col, row, true, this.StartOfWeek(DateTime.Now, DayOfWeek.Monday) + new TimeSpan(col, row, 0, 0));
                }
            }
        }

        public void SetPeriodValue(int col, int row, string text, Color color)
        {
            plan[col][row].Text = text;
            plan[col][row].Color = color;
        }

        public void SetPeriodValue(string text, Color color, List<Period> periods)
        {
            foreach (Period period in periods)
            {
                plan[period.Column][period.Row].Text = text;
                plan[period.Column][period.Row].Color = color;
            }
        }

        public Period GetPeriod(int col, int row)
        {
            return plan[col][row];
        }
        
        public int GetSimilarPeriodsLength(int col, int row)
        {
            int count = 1;
            for (int i = row + 1; i < 10; i++)
            {
                if (plan[col][i].Text == plan[col][row].Text && plan[col][i].Color == plan[col][row].Color)
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

        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }


    }
}
