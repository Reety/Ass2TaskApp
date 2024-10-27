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

        private TimeBlockViewModel? currentTimeBlock;
        public TimeBlockViewModel? CurrentTimeBlock { 
            get => currentTimeBlock;
            set
            {
                currentTimeBlock = value;
                OnPropertyChanged();
            }
        }

        private UserTaskViewModel currentTask;
        private SessionStart seshStartView;

        public UserTaskViewModel CurrentTask
        {
            get { return currentTask; }
            set 
            {
                if (CurrentTimeBlock != null)
                {
                    CurrentTimeBlock.CurrentTask = value;
                }
                
                currentTask = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserTaskViewModel> AllTasks { get; set; } = [];
        //public ObservableCollection<UserTaskViewModel> SelectedItems = [];
        public SessionStartViewModel(SessionStart seshView)
        {
            this.seshStartView = seshView;
            TaskSessionList.Tasks.ForEach(t => AllTasks.Add(new UserTaskViewModel(t)));
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => (seshStartView.SelectedItems != null && CurrentTimeBlock == null));

        private void StartSession()
        {
            TimeBlock tbModel = new TimeBlock();
            CurrentTimeBlock = new TimeBlockViewModel(tbModel);

            currentSeshTimer = new SessionTimer(new TimeSpan(0, 20, 0));

            foreach (UserTaskViewModel task in seshStartView.SelectedItems) {
                CurrentTimeBlock.AddTask(task);
            }
        }

        private void StartTimer()
		{

		}
	}
}
