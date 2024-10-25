using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;
using YourTimeApp.DB;

namespace YourTimeApp.ViewModels
{
    internal class AddTaskViewModel : ViewModelBase
    {
        #region Timer Properties
        private int hours;
        public int Hours
        {
            get => hours;
            set
            {
                hours = value;
                OnPropertyChanged();
            }
        }

        private int minutes;
        public int Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                OnPropertyChanged();
            }
        }

        private int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                seconds = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserTask> Tasks { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddTask(),canExecute => !(TaskDescription == null || TaskDescription == string.Empty));

        public AddTaskViewModel()
        {
            Tasks = new ObservableCollection<UserTask>(TaskSessionList.Tasks);
        }

        private void AddTask()
        {
            Tasks.Add(new UserTask(TaskDescription)
            {
                AllocatedTime = new TimeSpan(Hours, Minutes, Seconds)
            });
        }
    }
}
