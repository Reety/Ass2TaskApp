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
    /// <summary>
    /// class that attaches INotifyPropertyChange to UserTask properties so that it's reflected in the GUI
    /// </summary>
    public class UserTaskViewModel : ViewModelBase
    {
        public UserTask Task;
        public string TaskDescription
        {
            get => Task.Description;
            set
            { 
                Task.Description = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan AllocatedTime
        {
            get => Task.AllocatedTime;
            set
            {
                Task.AllocatedTime = value;
                OnPropertyChanged();
            }
        }
        public bool IsComplete
        {
            get => Task.isComplete;
            set
            {
                Task.isComplete = value;
                OnPropertyChanged();
            }
        }

        public UserTaskViewModel(UserTask task)
        {
            Task = task;
        }

        public override string ToString()
        {
            return TaskDescription;
        }
    }
}
