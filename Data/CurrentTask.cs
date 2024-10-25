using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace YourTimeApp.Data
{
    public class CurrentTask
    {
        public static UserTask Task { get; set; } = null;
        public static DateTime TimeStarted { get; private set; } 

        public static TimeSpan TimeElapsed => DateTime.Now - TimeStarted;
        public static DispatcherTimer Timer { get; } = new DispatcherTimer();

        public static TimeSpan TimeLeft => Timer.Interval - TimeElapsed;

        public delegate void TimerEnder(UserTask task); 
        public static event TimerEnder TimerEnd;

        static CurrentTask()
        {
            Timer.Tick += StopTimer;
        }

        public static void StartTimer(float timeAlloc)
        {
            Timer.Interval = TimeSpan.FromMinutes(timeAlloc);
            Timer.Start();
            TimeStarted = DateTime.Now;
        }

        public static void StartTimer(TimeSpan timeAlloc)
        {
            Timer.Interval = timeAlloc;
            Timer.Start();
            TimeStarted = DateTime.Now;
        }


        private static void StopTimer(Object source, EventArgs e)
        {
            Timer.Stop();
            TimerEnd?.Invoke(Task);

        }


    }
}
