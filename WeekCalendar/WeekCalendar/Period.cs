using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeekCalendar
{
    internal class Period
    {
        private Color color;
        private string text;
        private int column, row;
        private bool enabled;
        private DateTime start, end;

        public Period(Color color, string text, int column, int row, bool enabled)
        {
            this.color = color;
            this.text = text;
            this.column = column;
            this.row = row;
            this.enabled = enabled;
        }

        public Period(Color color, string text, int column, int row, bool enabled, DateTime start)
        {
            this.start = start;
            this.end = start + new TimeSpan(0, 30, 0);
            this.color = color;
            this.text = text;
            this.column = column;
            this.row = row;
            this.enabled = enabled;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
    }
}
