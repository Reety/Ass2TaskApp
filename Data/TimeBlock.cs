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
        public List<(UserTask task,TimeSpan timeSpent)> TaskTimes { get; set; } = [];

        public delegate void OnTaskEnd();
        public event OnTaskEnd CurrentTaskFinished;

        public TimeBlock()
        {
        }

        public bool AddTask(UserTask task)
        {
            if (TaskExists(task)) return false;
            TaskTimes.Add((task, TimeSpan.Zero));
            SetCurrentTask(task);
            return true;
        }

        public void SetCurrentTask(UserTask task)
        {
            CurrentTask.Task = task;
            CurrentTask.StartTimer(TaskTimes.Where(t => t.task == task).Select(x => x.timeSpent).First());
            CurrentTask.TimerEnd += NotifyTaskEnd;
        }

        public void NotifyTaskEnd(UserTask task)
        {
            CurrentTask.TimerEnd -= NotifyTaskEnd;
            CurrentTaskFinished?.Invoke();

        }

        private bool TaskExists(UserTask task)
        {
            return TaskTimes.Select(t => t.task).Contains(task);
        }


    }
}
