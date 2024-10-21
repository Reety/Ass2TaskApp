using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace YourTimeApp.Data
{
    public class SessionBlock
    {
        public int Id { get; set; }
        public TimeSpan TimeAlloc { get; set; }
        public SessionTimer Timer { get; set; }
        public Dictionary<ToDo, TimeSpan?> ToDos { get; set; } = [];

        public delegate void OnTaskEnd();
        public event OnTaskEnd CurrentTaskFinished;

        public SessionBlock(TimeSpan time)
        {
            Timer = new SessionTimer(time);
            TimeAlloc = time;
        }

        public void AddToDo(string name)
        {
            ToDo newTask = new ToDo(name);
            ToDos.Add(newTask, TimeSpan.Zero);
            SetCurrentTask(newTask);
        }

        public void SetCurrentTask(ToDo task)
        {
            CurrentTask.Task = task;
            CurrentTask.StartTimer(0.5f);
            CurrentTask.TimerEnd += NotifyTaskEnd;
        }

        public void NotifyTaskEnd(ToDo task)
        {
            CurrentTask.TimerEnd -= NotifyTaskEnd;
            CurrentTaskFinished?.Invoke();

        }

    }
}
