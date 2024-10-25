using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private UserTask _task;
        public string TaskDescription
        {
            get => _task.Description;
            set
            { 
                _task.Description = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan AllocatedTime
        {
            get => _task.AllocatedTime;
            set
            {
                _task.AllocatedTime = value;
                OnPropertyChanged();
            }
        }
        public bool IsComplete
        {
            get => _task.isComplete;
            set
            {
                _task.isComplete = value;
                OnPropertyChanged();
            }
        }

        public TaskViewModel(UserTask task)
        {
            _task = task;
        }

        public override string ToString()
        {
            return TaskDescription;
        }
    }
}
