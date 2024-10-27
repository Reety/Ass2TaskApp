using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    public class TimeBlockViewModel : ViewModelBase
    {
        public TimeBlock TimeBlock;

        public ObservableCollection<TaskTimeViewModel> TaskAndTimes { get; set; } = [];

        private TaskTimeViewModel? currentTask;

        public SessionTimer Timer;

        private TimeSpan timeRemaining;

        public TimeSpan TimeRemaining
        {
            get => timeRemaining;
            set { timeRemaining = value; OnPropertyChanged(); }
        }

        public TaskTimeViewModel? CurrentTask
        { get => currentTask;
            set
            {
                if (currentTask ==  value) return;
                currentTask = value;
                foreach (TaskTimeViewModel tt in TaskAndTimes)
                {
                    if (tt == currentTask) tt.IsCurrentTask = true;
                    else tt.IsCurrentTask = false;
                }
            }
        }

        public TimeBlockViewModel(TimeBlock timeBlock)
        {
            TimeBlock = timeBlock;
            Timer = new SessionTimer(TimeSpan.FromMinutes(10));
            TimeRemaining = Timer.TimeRemaining;
            Timer.Tick += updateTimeRemaining;
        }

        public void AddTask(UserTaskViewModel taskViewModel)
        {
            if (TimeBlock.AddTask(taskViewModel.Task) == false)
            {
                Debug.Print("Task already added");
            }

            if (TaskExists(taskViewModel)) return;

            TaskAndTimes.Add(new TaskTimeViewModel(taskViewModel, TimeSpan.Zero));
        }

        private bool TaskExists(UserTaskViewModel taskViewModel) {

            return TaskAndTimes.Select(t => t.Task).Contains(taskViewModel);
        }

        public void EndBlock()
        {

        }

        private void updateTimeRemaining(Object source, EventArgs e)
        {
            if (Timer == null) return;
            TimeRemaining = Timer.TimeRemaining;
        }
    }
}
