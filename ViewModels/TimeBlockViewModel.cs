using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class TimeBlockViewModel : ViewModelBase
    {
        public TimeBlock TimeBlock;

        public ObservableCollection<TaskTimeViewModel> TaskAndTimes = [];

        public UserTaskViewModel CurrentTask;
        public TaskTimeViewModel CurrentTaskTime => TaskAndTimes.FirstOrDefault(t => t.Task == CurrentTask);

        public TimeBlockViewModel(TimeBlock timeBlock)
        {
            TimeBlock = timeBlock;
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
    }
}
