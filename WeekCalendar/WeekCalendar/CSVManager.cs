using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WeekCalendar
{
    internal class CSVManager
    {
        public void Save(DateTime start, Period[][] periods)
        {
            System.IO.Directory.CreateDirectory("planerdata");
            Debug.WriteLine("Saving to CSV: " + PathFromDateTime(start));
            if (periods.Length != 7)
            {
                throw new ArgumentException("periods must be 7 days long");
            }
            if (periods.All(x => x.Length != 24))
            {
                throw new ArgumentException("periods must be 12 hours long");
            }
            var sb = new StringBuilder();
            Array.ForEach(periods, day =>
            {
                Array.ForEach(day, period =>
                {
                    sb.Append(period.ToCSV());
                    sb.AppendLine();
                });
            });
            sb.Remove(sb.Length - 1, 1);


            File.WriteAllText(PathFromDateTime(start), sb.ToString());
        }

        public Period[][] Load(DateTime start)
        {
            Debug.WriteLine("Loading from CSV: " + PathFromDateTime(start));
            if(!File.Exists(PathFromDateTime(start)))
            {
                Debug.WriteLine("File doesn't exist");
                return null;
            }
            var lines = File.ReadAllLines(PathFromDateTime(start));
            var periods = new Period[7][];
            for (int i = 0; i < 7; i++)
            {
                periods[i] = new Period[24];
                for (int j = 0; j < 24; j++)
                {
                    periods[i][j] = Period.FromCSV(lines[i * 24 + j]);
                }
            }
            return periods;
        }

        private string PathFromDateTime(DateTime date)
        {
            string p = "planerdata/" + date.ToString("d") + ".csv";
            return p;
        }
        
    }
}
