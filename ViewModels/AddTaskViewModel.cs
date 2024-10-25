using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;
using YourTimeApp.DB;

namespace YourTimeApp.ViewModels
{
    internal class AddTaskViewModel : ViewModelBase
    {
        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserTask> Tasks { get; set; }

        //public RelayCommand AddCommand => new RelayCommand

        public AddTaskViewModel()
        {
            Tasks = new ObservableCollection<UserTask>(TaskSessionList.Tasks);
        }

        private void AddTask()
        {
           
        }
    }
}
