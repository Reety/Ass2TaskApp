using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace YourTimeApp.Data
{
    public class TimeBlock
    {
        public int Id { get; set; }
        public TimeSpan TotalTime { get; set; }
        public SessionTimer Timer { get; set; }
        public Dictionary<UserTask,TimeSpan> TaskTimes { get; set; } = [];

        public delegate void OnTaskEnd();
        public event OnTaskEnd CurrentTaskFinished;

        public TimeBlock()
        {
        }

        public bool AddTask(UserTask task)
        {
            if (TaskExists(task)) return false;
            TaskTimes[task] = TimeSpan.Zero;
            return true;
        }



        private bool TaskExists(UserTask task)
        {
           return TaskTimes.ContainsKey(task);
        }


    }
}
