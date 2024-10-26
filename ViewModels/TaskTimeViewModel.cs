using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class TaskTimeViewModel : ViewModelBase
    {
        public UserTaskViewModel Task;

        private TimeSpan timeSpent;
        public TimeSpan TimeSpent
        {
            get => timeSpent; 
            set
            {
                timeSpent = value;
                OnPropertyChanged();
            }
        }
        public TaskTimeViewModel(UserTaskViewModel task, TimeSpan time)
        {
            Task = task;
            TimeSpent = time;
        }

    }
}
