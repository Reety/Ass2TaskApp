using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace YourTimeApp.Data
{
    public class SessionTimer
    {
        private TimeSpan timeBlock;
        private DateTime startTime;
        private DispatcherTimer seshTimer;

        public string TimeLeft { get; private set; }
        public bool TimerEnabled => seshTimer.IsEnabled;

        public SessionTimer(TimeSpan time)
        {
            timeBlock = time;
            seshTimer = new DispatcherTimer();
            seshTimer.Interval = TimeSpan.FromSeconds(1);
            seshTimer.Tick += onOneSecond;
        }

        public void Start()
        {
            startTime = DateTime.Now;
            seshTimer.Start();
        }

        private void onOneSecond(Object source, EventArgs e) {
            DateTime currTime = DateTime.Now;
            TimeSpan elapsedTime = currTime - startTime;
            TimeLeft = elapsedTime.ToString("c");
            if (elapsedTime == timeBlock) seshTimer.Stop();
        }
    }
}
