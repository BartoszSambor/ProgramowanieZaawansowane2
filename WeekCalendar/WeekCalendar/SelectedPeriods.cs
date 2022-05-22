using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WeekCalendar
{
    internal class SelectedPeriods
    {
        private List<Period> selected;

        public SelectedPeriods()
        {
            selected = new List<Period>();
        }

        public void SelectPeriod(Period period)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                selected.Add(period);
            }
            else if (selected.Count == 0)
            {
                selected.Add(period);
            }
            else
            {

                int min = 10, max = -10;
                // Search for the min and max row in selected
                foreach (Period p in selected)
                {
                    if (p.Row <= min)
                    {
                        min = p.Row;
                    }
                    if (p.Row >= max)
                    {
                        max = p.Row;
                    }
                }
                Debug.WriteLine("Max: " + max + " Min: " + min);
                if (period.Column == selected[0].Column && (period.Row == max + 1 || period.Row == min - 1))
                {
                    selected.Add(period);
                }
                else
                {
                    selected.Clear();
                    selected.Add(period);
                }
            }
 

            Debug.WriteLine("/////////////////");
            Debug.WriteLine(selected[0].Column.ToString() + " " + period.Column.ToString());
            foreach (var s in selected)
            {
                Debug.WriteLine("Selected: " + s.Column + " " + s.Row);
            }
        }

        public bool IsSelected(int column, int row)
        {
            foreach (Period p in selected)
            {
                if (p.Column == column && p.Row == row)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Period> GetSelectedPeriods()
        {
            return selected;
        }
    }
}
