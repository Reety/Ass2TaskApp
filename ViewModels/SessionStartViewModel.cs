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
        private SessionStart seshStartView;

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
        public SessionStartViewModel(SessionStart seshView)
        {
            this.seshStartView = seshView;
            TaskSessionList.Tasks.ForEach(t => AllTasks.Add(new UserTaskViewModel(t)));
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => StartSession(), canExecute => (seshStartView.SelectedItems != null && currentTimeBlock == null));

        private void StartSession()
        {
            TimeBlock tbModel = new TimeBlock();
            currentTimeBlock = new TimeBlockViewModel(tbModel);

            currentSeshTimer = new SessionTimer(new TimeSpan(0, 20, 0));

            foreach (UserTaskViewModel task in seshStartView.SelectedItems) {
                currentTimeBlock.AddTask(task);
            }
        }

        private void StartTimer()
		{

		}
	}
}
