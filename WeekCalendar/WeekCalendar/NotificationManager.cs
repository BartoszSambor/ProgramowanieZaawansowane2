using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekCalendar
{
    internal class NotificationManager
    {
        public NotificationManager()
        {
            Timer timer = new Timer();
            timer.Interval = 1000 * 30;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

        }
    }
}
