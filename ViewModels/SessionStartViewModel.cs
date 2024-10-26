using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using YourTimeApp.Data;
using YourTimeApp.DB;

namespace YourTimeApp.ViewModels
{
    internal class SessionStartViewModel : ViewModelBase
    {
        public SessionTimer currentSeshTimer;
        public TimeBlockViewModel currentTimeBlock;

        private UserTaskViewModel currentTask;

        public UserTaskViewModel CurrentTask
        {
            get { return currentTask; }
            set 
            {
                if (currentTimeBlock != null)
                {
                    currentTimeBlock.CurrentTask = value;
                }
                
                currentTask = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserTaskViewModel> AllTasks { get; set; } = [];
        //public ObservableCollection<UserTaskViewModel> SelectedItems = [];
        public SessionStartViewModel()
        {
            TaskSessionList.Tasks.ForEach(t => AllTasks.Add(new UserTaskViewModel(t)));
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => SelectedItems != null);

        private void StartSession()
        {
            TimeBlock currentBlock = new TimeBlock();
            currentTimeBlock = new TimeBlockViewModel(currentBlock);

            currentSeshTimer = new SessionTimer(new TimeSpan(0, 20, 0));

            foreach (var task in SelectedItems)
            {
                currentTimeBlock.AddTask(task);
            }
        }

        private void StartTimer()
		{

		}
	}
}
