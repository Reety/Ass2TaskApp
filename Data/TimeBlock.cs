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
        public Dictionary<UserTask, TimeSpan> TaskTimes { get; set; } = [];

        public delegate void OnTaskEnd();
        public event OnTaskEnd CurrentTaskFinished;

        public TimeBlock()
        {
        }

        public void AddToDo(string name)
        {
            UserTask newTask = new UserTask(name);
            TaskTimes.Add(newTask, TimeSpan.Zero);
            SetCurrentTask(newTask);
        }

        public void AddToDo(string name, float time)
        {
            UserTask newTask = new UserTask(name);
            TaskTimes.Add(newTask, TimeSpan.FromMinutes(time));
            SetCurrentTask(newTask);
        }
        public void SetCurrentTask(UserTask task)
        {
            CurrentTask.Task = task;
            CurrentTask.StartTimer(TaskTimes[task]);
            CurrentTask.TimerEnd += NotifyTaskEnd;
        }

        public void NotifyTaskEnd(UserTask task)
        {
            CurrentTask.TimerEnd -= NotifyTaskEnd;
            CurrentTaskFinished?.Invoke();

        }

    }
}
