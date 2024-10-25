using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace YourTimeApp.Data
{
    public class SessionTimer : DispatcherTimer
    {
        private TimeSpan TimeAllocated;
        private DateTime startTime;
        private Stopwatch stopWatch = new Stopwatch();
        private DispatcherTimer seshTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromSeconds(1),
        };

        public TimeSpan TimeRemaining { get; private set; }

        public TimeSpan ElapsedTime => TimeAllocated - TimeRemaining;
        public bool TimerEnabled => stopWatch.IsRunning;

        public SessionTimer(TimeSpan time) : base()
        {
            TimeAllocated = time;
            Interval = TimeSpan.FromSeconds(1);

            Tick += everySecond;
        }

        public new void Start()
        {
            startTime = DateTime.Now;
            base.Start();
            stopWatch.Start();
        }

        public void Pause()
        {
            base.Stop();
            stopWatch.Stop();
        }

        public void Resume()
        {
            if (stopWatch.IsRunning) return;

            base.Start();
            stopWatch.Start();
        }

        public new void Stop()
        {
            base.Stop();
            stopWatch.Reset();
        }

        private void everySecond(Object source, EventArgs e) {
            TimeRemaining = TimeAllocated - stopWatch.Elapsed;
            if (stopWatch.Elapsed == TimeAllocated) this.Stop();
        }
    }
}
