using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekCalendar
{
    internal class NotificationManager
    {
        Period[][] periods;
        uint timeBefore;
        public NotificationManager()
        {
            this.Load();
        }
        

        public void Load()
        {
            periods = new CSVManager().Load(StartOfWeek(DateTime.Now));
        }

        public Period GetPlannedEvent(DateTime time)
        {
            if (periods is null)
            {
                return null;
            }
            foreach (var day in periods)
            {
                foreach (var p in day)
                {
                    var diff = p.Start - time;                   
                    if (diff < new TimeSpan(0, 0, (int)timeBefore + 1, 0) && diff > new TimeSpan(0, 0, (int)timeBefore, 0) && p.Text != String.Empty)
                    {
                        return p;
                    }
                }
            }
            return null;
        }
        public DateTime StartOfWeek(DateTime dt)
        {
            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            return monday;
        }
        public void SetTimeBefore(uint time)
        {
            timeBefore = time;
        }
    }


}
