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
    /// <summary>
    ///     Custom timer that inherits from DispatcherTimer and implements pause functionality 
    /// </summary>
    public class SessionTimer : DispatcherTimer
    {
        private TimeSpan TimeAllocated;
        private Stopwatch stopWatch = new Stopwatch();

        public TimeSpan TimeRemaining { get; private set; }

        public TimeSpan ElapsedTime => TimeAllocated - TimeRemaining;

        public bool TimerEnded { get; private set; } = false;
        public bool TimerStarted { get; private set; } = false;
        public bool Paused => !stopWatch.IsRunning;

        public SessionTimer(TimeSpan time) : base()
        {
            TimeAllocated = time;
            Interval = TimeSpan.FromSeconds(1);

            Tick += everySecond;
        }

        public new void Start()
        {
            base.Start();
            stopWatch.Start();
            TimerStarted = true;
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
            TimerEnded = true;
        }

        private void everySecond(Object source, EventArgs e) {
            TimeRemaining = TimeAllocated - stopWatch.Elapsed;
            if (stopWatch.Elapsed == TimeAllocated) this.Stop();
        }
    }
}
