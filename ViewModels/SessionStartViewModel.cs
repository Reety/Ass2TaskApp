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
        public ObservableCollection<UserTaskViewModel> Tasks { get; set; }
        public ObservableCollection<UserTaskViewModel> SelectedItems = [];
        public SessionStartViewModel()
        {
            TaskSessionList.Tasks.ForEach(t => Tasks.Add(new UserTaskViewModel(t)));
                  
        }



		public RelayCommand StartTimeCommand => new RelayCommand(execute => { }, canExecute => { return true; });
        public RelayCommand StartSeshCommand => new RelayCommand(execute => { }, canExecute => { return true; });

        private void StartSession()
        {
            TimeBlock currentBlock = new TimeBlock();
            currentSeshTimer = new SessionTimer(new TimeSpan(0, 20, 0));

            foreach (var task in SelectedItems)
            {
                currentBlock.AddTask(task.Task);
            }
        }
        private void StartTimer()
		{

		}
	}
}
